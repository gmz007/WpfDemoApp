namespace DemoApp.Settings
{
    /// <summary>
    /// Interface to read and write from database.
    /// Database refers to the storage for the settings, it could be a file or an actual database.
    /// </summary>
    public interface ISettingsDatabase
    {
        TValue? GetValue<TValue>(string key, TValue? defaultValue = default);

        bool SetValue<TValue>(string key, TValue? newValue);
    }
}
