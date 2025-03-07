using DemoApp.Views;
using System.Windows;
using System.Windows.Controls;

namespace DemoApp.UserControls
{
    /// <summary>
    /// Interaction logic for AddressBar.xaml
    /// </summary>
    public partial class AddressBar : UserControl
    {
        public AddressBar()
        {
            InitializeComponent();
        }

        private void SettingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new SettingsView()
            {
                Owner = Window.GetWindow(this)
            };
                
            settingsWindow.ShowDialog();
        }
    }
}
