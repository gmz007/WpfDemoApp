using System.IO;
using System.Text.Json;

namespace DemoApp.Settings.Implementation
{
    public class JsonSettingsDatabase : ISettingsDatabase
    {
        private string SettingsFile { get; }

        public JsonSettingsDatabase(string filePath)
        {
            SettingsFile = filePath;
        }

        public TValue? GetValue<TValue>(string key, TValue? defaultValue = default)
        {
            var settings = GetSettings();

            if (settings.TryGetValue(key, out var objValue))
            {
                return ParseObject<TValue>(objValue) ?? defaultValue;
            }

            SetValue(key, defaultValue);
            return defaultValue;
        }

        public bool SetValue<TValue>(string key, TValue? newValue)
        {
            var settings = GetSettings();

            if (!settings.TryAdd(key, newValue))
            {
                settings[key] = newValue;
            }

            return SaveSettings(settings);
        }

        private Dictionary<string, object?> GetSettings()
        {
            var fileInfo = new FileInfo(SettingsFile);

            if (!fileInfo.Exists)
            {
                if (fileInfo.DirectoryName == null)
                {
                    return new Dictionary<string, object?>();
                }

                Directory.CreateDirectory(fileInfo.DirectoryName);

                var fs = File.Create(fileInfo.FullName);
                fs.Close();
            }

            var data = File.ReadAllText(SettingsFile);

            if (string.IsNullOrWhiteSpace(data))
            {
                data = "null";
            }

            return JsonSerializer.Deserialize<Dictionary<string, object?>>(data) ?? new();
        }

        private bool SaveSettings(Dictionary<string, object?> settings)
        {
            var fileInfo = new FileInfo(SettingsFile);

            if (!fileInfo.Exists)
            {
                if (fileInfo.DirectoryName == null)
                {
                    return false;
                }

                Directory.CreateDirectory(fileInfo.DirectoryName);

                var fs = File.Create(fileInfo.FullName);
                fs.Close();
            }
            
            File.WriteAllText(fileInfo.FullName, JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true }));
            return true;
        }

        private static TValue? ParseObject<TValue>(object? objValue)
        {
            if (objValue is JsonElement jsonElement)
            {
                return jsonElement.Deserialize<TValue>();
            }

            return (TValue?)objValue;
        }
    }
}
