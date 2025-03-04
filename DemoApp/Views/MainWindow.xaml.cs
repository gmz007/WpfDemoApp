using DemoApp.Helpers;
using DemoApp.ViewModels;
using DemoApp.Views;
using System.Windows;

namespace DemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(App.Current.UserSettings);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new FluentDialog()
            {
                Owner = this,
                Title = LocalizationSource.Instance["GreetingsDialogTitle"],
                Content = LocalizationSource.Instance["GreetingsDialogContent"],
                PrimaryButtonText = LocalizationSource.Instance["Confirm"],
                CloseButtonText = LocalizationSource.Instance["Cancel"],
                DefaultButton = FluentDialogButton.Primary
            };

            var result = dialog.ShowDialog();
        }
    }
}