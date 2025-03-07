using DemoApp.ViewModels;
using System.Windows;

namespace DemoApp.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        private SettingsViewModel _viewModel;

        public SettingsView()
        {
            InitializeComponent();
            DataContext = _viewModel = new SettingsViewModel(App.Current.UserSettings);
        }
    }
}
