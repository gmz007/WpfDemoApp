using DemoApp.Settings;
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
            UserSettings = new UserSettings(new JsonSettingsDatabase(
                Path.Combine(AppContext.BaseDirectory, Constants.Settings.SettingsDirectory),
                Constants.Settings.UserSettingsFile)
            );
        }

        public new static App Current => (App)Application.Current;

        public IUserSettings UserSettings { get; }
    }
}
