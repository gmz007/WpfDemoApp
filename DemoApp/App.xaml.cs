using DemoApp.Settings;
using DemoApp.Settings.Implementation;
using System.IO;
using System.Windows;

namespace DemoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var userSettingsFilePath = Path.Combine(AppContext.BaseDirectory, Constants.Settings.SettingsDirectory, Constants.Settings.UserSettingsFile);
            UserSettings = new UserSettings(new JsonSettingsDatabase(userSettingsFilePath));
        }

        public new static App Current => (App)Application.Current;

        public IUserSettings UserSettings { get; }
    }
}
