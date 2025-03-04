using System.Windows;
using DemoApp.ViewModels;
using DemoApp.Views;

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
                Title = "Title",
                Content = "This is the content body.",
                PrimaryButtonText = "Ok",
                CloseButtonText = "Cancel",
                DefaultButton = FluentDialogButton.Primary
            };

            var result = dialog.ShowDialog();
        }
    }
}