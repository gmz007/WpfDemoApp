using System.IO;
using System.Text.Json;

namespace DemoApp.Settings
{
    public class JsonSettingsDatabase : ISettingsDatabase
    {
        private string SettingsFile { get; }

        public JsonSettingsDatabase(string settingsDirectory, string settingsFile)
        {
            SettingsFile = Path.Combine(settingsDirectory, settingsFile);

            if (!Directory.Exists(settingsDirectory))
            {
                var di = Directory.CreateDirectory(settingsDirectory);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            if (!File.Exists(SettingsFile))
            {
                using var _ = File.Create(SettingsFile);
            }
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
            var data = File.ReadAllText(SettingsFile);

            if (string.IsNullOrWhiteSpace(data))
            {
                data = "null";
            }

            return JsonSerializer.Deserialize<Dictionary<string, object?>>(data) ?? new();
        }

        private bool SaveSettings(Dictionary<string, object?> settings)
        {
            File.WriteAllText(SettingsFile, JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true }));
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
