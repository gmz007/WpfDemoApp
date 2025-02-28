using DemoApp.Helpers;
using DemoApp.Mvvm.ViewModel;
using DemoApp.Settings;
using System.Collections.ObjectModel;
using System.Globalization;

namespace DemoApp
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly IUserSettings _userSettings;

        public MainWindowViewModel(IUserSettings userSettings)
        {
            _userSettings = userSettings;

            Languages = new ObservableCollection<string>(Constants.Languages.Keys);
            SelectedLanguage = Constants.Languages.FirstOrDefault(lang => lang.Value.Equals(userSettings.Language)).Key ?? "English";

            LocalizationSource.Instance.CurrentCulture = new CultureInfo(userSettings.Language);
        }

        public ObservableCollection<string> Languages { get; }

        private string _selectedLanguage = string.Empty;

        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (_selectedLanguage == value)
                    return;

                LocalizationSource.Instance.CurrentCulture = new CultureInfo(Constants.Languages.GetValueOrDefault(value, "en"));
                _userSettings.Language = Constants.Languages.GetValueOrDefault(value, "en");
                _selectedLanguage = value;
            }
        }
    }
}
