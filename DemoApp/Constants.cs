namespace DemoApp
{
    public static class Constants
    {
        public static readonly Dictionary<string, string> Languages = new()
        {
            { "简体中文", "zh-hans" },
            { "繁體中文", "zh-hant" },
            { "English", "en" },
            { "Français", "fr" },
            { "Español", "es" },
        };

        public static class Settings
        {
            public const string SettingsDirectory = "settings";

            public const string UserSettingsFile = "user_settings.json";
        }
    }
}
