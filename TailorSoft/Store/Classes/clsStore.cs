using System.Text.Json;
using System.Text.Json.Serialization;

namespace TailorSoft.Store.Classes
{
    /// <summary>
    /// Represents the store information persisted to disk for TailorSoft.
    /// Save / Load methods use a JSON file under %AppData%\TailorSoft\store.json by default.
    /// </summary>
    public class clsStore
    {
        // Public properties that will be serialized
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// File path to the logo image. This can be an absolute path or a path inside the app data folder.
        /// </summary>
        public string LogoImagePath { get; set; } = string.Empty;

        /// <summary>
        /// Timestamp for last update (useful for debugging or UI).
        /// </summary>
        public DateTime LastUpdatedUtc { get; set; } = DateTime.UtcNow;

        // --- Configuration / defaults ---
        [JsonIgnore]
        public static string AppFolderName { get; set; } = "TailorSoft";

        [JsonIgnore]
        public static string DefaultFileName { get; set; } = "store.json";

        [JsonIgnore]
        public static string DefaultDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppFolderName);

        [JsonIgnore]
        public static string DefaultFilePath => Path.Combine(DefaultDirectory, DefaultFileName);

        // JSON options
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        // --- Constructors ---
        public clsStore() { }

        public clsStore(string name, string phone, string address, string logoImagePath = "")
        {
            Name = name ?? string.Empty;
            Phone = phone ?? string.Empty;
            Address = address ?? string.Empty;
            LogoImagePath = logoImagePath ?? string.Empty;
            LastUpdatedUtc = DateTime.UtcNow;
        }

        // --- Save / Load (sync) ---
        /// <summary>
        /// Save this store to the default file path (or a custom path) synchronously.
        /// Creates the directory if it does not exist.
        /// Throws exceptions on IO errors - catch them in your UI code.
        /// </summary>
        public void Save(string? filePath = null)
        {
            var path = filePath ?? DefaultFilePath;
            EnsureDirectoryExists(Path.GetDirectoryName(path)!);
            LastUpdatedUtc = DateTime.UtcNow;
            var json = JsonSerializer.Serialize(this, _jsonOptions);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Load the store from the default file path. If file does not exist returns a new clsStore object (not null).
        /// </summary>
        public static clsStore Load(string? filePath = null)
        {
            var path = filePath ?? DefaultFilePath;
            if (!File.Exists(path))
                return new clsStore();

            var json = File.ReadAllText(path);
            try
            {
                var store = JsonSerializer.Deserialize<clsStore>(json, _jsonOptions);
                if (store == null)
                    return new clsStore();
                return store;
            }
            catch
            {
                // If file is corrupted or format changed, return fresh object so UI can continue.
                return new clsStore();
            }
        }

        // --- Async variants ---
        public async Task SaveAsync(string? filePath = null)
        {
            var path = filePath ?? DefaultFilePath;
            EnsureDirectoryExists(Path.GetDirectoryName(path)!);
            LastUpdatedUtc = DateTime.UtcNow;
            using var fs = File.Create(path);
            await JsonSerializer.SerializeAsync(fs, this, _jsonOptions);
            await fs.FlushAsync();
        }

        public static async Task<clsStore> LoadAsync(string? filePath = null)
        {
            var path = filePath ?? DefaultFilePath;
            if (!File.Exists(path))
                return new clsStore();

            try
            {
                using var fs = File.OpenRead(path);
                var store = await JsonSerializer.DeserializeAsync<clsStore>(fs, _jsonOptions);
                return store ?? new clsStore();
            }
            catch
            {
                return new clsStore();
            }
        }

        // --- Helpers ---
        private static void EnsureDirectoryExists(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory))
                return;

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        /// <summary>
        /// Set logo by copying the provided source file into the app data "Assets" folder (optional) and update LogoImagePath.
        /// Returns the final path that was saved in LogoImagePath.
        /// If copyToAppFolder is false, the method will just set LogoImagePath to sourcePath (no copy).
        /// </summary>
        public string SetLogoFromFile(string sourcePath, bool copyToAppFolder = true)
        {
            if (string.IsNullOrWhiteSpace(sourcePath) || !File.Exists(sourcePath))
                throw new FileNotFoundException("Logo source file not found", sourcePath);

            if (!copyToAppFolder)
            {
                LogoImagePath = sourcePath;
                LastUpdatedUtc = DateTime.UtcNow;
                return LogoImagePath;
            }

            var assetsDir = Path.Combine(DefaultDirectory, "Assets");
            EnsureDirectoryExists(assetsDir);

            var ext = Path.GetExtension(sourcePath);
            var fileName = "logo" + ext; // you can change naming strategy (timestamp, guid, etc.)
            var dest = Path.Combine(assetsDir, fileName);

            // Overwrite existing file
            File.Copy(sourcePath, dest, true);

            LogoImagePath = dest;
            LastUpdatedUtc = DateTime.UtcNow;
            return LogoImagePath;
        }

        /// <summary>
        /// Delete stored logo file (if it exists) and clear LogoImagePath.
        /// </summary>
        public void RemoveLogoFile()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(LogoImagePath) && File.Exists(LogoImagePath))
                    File.Delete(LogoImagePath);
            }
            catch
            {
                // ignore IO exceptions here — let UI notify user if needed
            }

            LogoImagePath = string.Empty;
            LastUpdatedUtc = DateTime.UtcNow;
        }
    }
}


