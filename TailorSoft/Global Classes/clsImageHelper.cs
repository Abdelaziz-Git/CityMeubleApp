using System.Collections.Concurrent;
using TailorSoft.Properties;


public static class clsImageHelper
{
    // Thread-safe cache
    private static readonly ConcurrentDictionary<string, Image> _cache = new(StringComparer.OrdinalIgnoreCase);

    // Usage order for LRU
    private static readonly LinkedList<string> _usageOrder = new();
    private static readonly object _lock = new();

    // Max cache size
    private static int _maxCacheSize = 100;
    public static int MaxCacheSize
    {
        get => _maxCacheSize;
        set
        {
            if (value <= 0) throw new ArgumentException("MaxCacheSize must be > 0");
            _maxCacheSize = value;
        }
    }
    /// <summary>
    /// Get image from cache or load from file.
    /// If Path is not exists return deffault image.
    /// </summary>
    public static Image? GetImage(string path)
    {
        if (string.IsNullOrEmpty(path) || !File.Exists(path))
            return Resources.empty_image_icon_512;

        // Return clone of cached image if exists
        if (_cache.TryGetValue(path, out var cached))
            return (Image)cached.Clone();

        // Load image bytes without locking file
        byte[] data = File.ReadAllBytes(path);
        using var ms = new MemoryStream(data);
        using var temp = Image.FromStream(ms);

        var bmp = new Bitmap(temp); // make independent copy
        _cache[path] = bmp; // store original in cache

        return (Image)bmp.Clone(); // give caller a copy
    }

    /// <summary>
    /// Get image async (from cache or load from file).
    /// Returns clone of cached image.
    /// </summary>
    public static async Task<Image?> GetImageAsync(string path)
    {
        if (string.IsNullOrEmpty(path) || !File.Exists(path))
            return Resources.empty_image_icon_512;

        // Already cached?
        if (_cache.TryGetValue(path, out var cached))
        {
            MoveToRecent(path);
            return (Image)cached.Clone();
        }

        // Load async
        Image bmp = await LoadImageFromFileAsync(path);

        lock (_lock)
        {
            _cache[path] = bmp;
            MoveToRecent(path);
            if (_cache.Count > _maxCacheSize)
                RemoveOldest();
        }

        return (Image)bmp.Clone();
    }

    /// <summary>
    /// Preload multiple images async (from DB list of paths).
    /// Loads them in background and stores in cache.
    /// </summary>
    public static async Task PreloadImagesAsync(IEnumerable<string> paths)
    {
        var tasks = new List<Task>();

        foreach (var path in paths)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
                continue;

            if (_cache.ContainsKey(path)) // already cached
                continue;

            tasks.Add(Task.Run(async () =>
            {
                var bmp = await LoadImageFromFileAsync(path);
                lock (_lock)
                {
                    _cache[path] = bmp;
                    MoveToRecent(path);
                    if (_cache.Count > _maxCacheSize)
                        RemoveOldest();
                }
            }));
        }

        await Task.WhenAll(tasks);
    }

    private static async Task<Image> LoadImageFromFileAsync(string path)
    {
        try
        {
            return await Task.Run(() =>
            {
                byte[] data = File.ReadAllBytes(path);
                using var ms = new MemoryStream(data);
                using var temp = Image.FromStream(ms);
                return new Bitmap(temp);
            });
        }
        catch (Exception)
        {
            return Resources.empty_image_icon_512; // return default image on error
        }
    }

    private static void MoveToRecent(string path)
    {
        lock (_lock)
        {
            _usageOrder.Remove(path);
            _usageOrder.AddFirst(path);
        }
    }

    private static void RemoveOldest()
    {
        var oldest = _usageOrder.Last?.Value;
        if (oldest != null && _cache.TryRemove(oldest, out var img))
        {
            img.Dispose();
            _usageOrder.RemoveLast();
        }
    }

    /// <summary>
    /// Clear cache
    /// </summary>
    public static void Clear()
    {
        foreach (var kv in _cache)
            kv.Value.Dispose();

        _cache.Clear();

        lock (_lock)
            _usageOrder.Clear();
    }




    public static List<string> GetAllImages(string rootFolder)
    {
        var results = new List<string>();
        TraverseDirectory(rootFolder, results);
        return results;
    }

    private static void TraverseDirectory(string folder, List<string> results)
    {
        try
        {
            foreach (var file in Directory.EnumerateFiles(folder, "*.*"))
            {
                if (file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(file);
                }
            }

            foreach (var dir in Directory.EnumerateDirectories(folder))
            {
                TraverseDirectory(dir, results); // recursive
            }
        }
        catch (UnauthorizedAccessException)
        {
            // ignore this folder
        }
        catch (PathTooLongException)
        {
            // ignore long path errors
        }
    }
}
