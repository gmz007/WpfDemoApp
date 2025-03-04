using DemoApp.Models;

namespace DemoApp
{
    public static class Constants
    {

        public static readonly LanguageInfo[] Languages =
        [
            new LanguageInfo("English", "en", new Uri(ResourceUri.UnitedStatesIcon)),
            new LanguageInfo("Español", "es", new Uri(ResourceUri.SpainIcon)),
            new LanguageInfo("Français", "fr", new Uri(ResourceUri.FranceIcon)),
            new LanguageInfo("简体中文", "zh-hans", new Uri(ResourceUri.ChinaIcon)),
            new LanguageInfo("繁體中文", "zh-hant", new Uri(ResourceUri.HongKongIcon)),
        ];

        public static class Settings
        {
            public const string SettingsDirectory = "settings";

            public const string UserSettingsFile = "user_settings.json";
        }

        public static class ResourceUri
        {
            public const string ChinaIcon = "pack://application:,,,/assets/icons/china.png";

            public const string FranceIcon = "pack://application:,,,/assets/icons/france.png";

            public const string HongKongIcon = "pack://application:,,,/assets/icons/hong-kong.png";

            public const string SpainIcon = "pack://application:,,,/assets/icons/spain.png";

            public const string UnitedStatesIcon = "pack://application:,,,/assets/icons/united-states.png";
        }
    }
}
