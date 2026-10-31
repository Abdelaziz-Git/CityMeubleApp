using System.Collections.Concurrent;

public static class AsyncImageCache
{
    // thread-safe cache (path -> Image that we own)
    private static readonly ConcurrentDictionary<string, Image> _cache =
        new ConcurrentDictionary<string, Image>(StringComparer.OrdinalIgnoreCase);

    // Maximum number of cached items before we clear (simple policy).
    // Tune this value or implement proper LRU eviction if you need.
    public static int MaxCacheItems { get; set; } = 500;

    public static async Task<Image?> GetImageAsync(string path, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(path) || !File.Exists(path))
            return null;

        // If cached, return a clone so caller can dispose safely.
        if (_cache.TryGetValue(path, out var cached) && cached != null)
            return (Image)cached.Clone();

        // If cache too large, clear it to prevent OOM (very basic).
        if (_cache.Count > MaxCacheItems)
        {
            Clear(); // or implement a smarter eviction
        }

        // Read file bytes asynchronously to avoid locking UI thread
        byte[] data;
        try
        {
            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            data = new byte[fs.Length];
            int read = 0;
            while (read < data.Length)
            {
                ct.ThrowIfCancellationRequested();
                int r = await fs.ReadAsync(data, read, data.Length - read, ct).ConfigureAwait(false);
                if (r == 0) break;
                read += r;
            }
        }
        catch (OperationCanceledException) { throw; }
        catch
        {
            return null;
        }

        ct.ThrowIfCancellationRequested();

        // Build a Bitmap from memory stream (this avoids file locks)
        using var ms = new MemoryStream(data);
        using var temp = Image.FromStream(ms);
        var bmp = new Bitmap(temp);      // independent Bitmap

        // store one shared instance in cache
        _cache[path] = bmp;

        // return a clone for caller ownership
        return (Image)bmp.Clone();
    }

    public static void Clear()
    {
        foreach (var kv in _cache)
        {
            try { kv.Value.Dispose(); } catch { }
        }
        _cache.Clear();
    }
}
