using DemoApp.Mvvm.ViewModel;
using DemoApp.Settings;
using DemoApp.ViewModels.Settings;

namespace DemoApp.ViewModels
{
    public class SettingsViewModel : ObservableObject
    {
        public SettingsViewModel(IUserSettings userSettings)
        {
            _currentViewModel = new GeneralSettingsViewModel(userSettings);
        }

        private ObservableObject _currentViewModel;

        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel;
            set => SetField(ref _currentViewModel, value);
        }
    }
}
