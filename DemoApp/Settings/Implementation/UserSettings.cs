using System.Runtime.CompilerServices;

namespace DemoApp.Settings
{
    public class UserSettings : IUserSettings
    {
        public string Language
        {
            get => Get("English");
            set => Set(value);
        }

        private ISettingsDatabase SettingsDatabase { get; }

        public UserSettings(ISettingsDatabase settingsDatabase)
        {
            SettingsDatabase = settingsDatabase;
        }

        public TValue Get<TValue>(TValue defaultValue, [CallerMemberName] string propertyName = "")
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return defaultValue;
            }

            return SettingsDatabase.GetValue(propertyName, defaultValue) ?? defaultValue;
        }

        public bool Set<TValue>(TValue value, [CallerMemberName] string propertyName = "")
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return false;
            }

            return SettingsDatabase.GetValue<TValue>(propertyName)?.Equals(value) is false && SettingsDatabase.SetValue(propertyName, value);
        }
    }
}
