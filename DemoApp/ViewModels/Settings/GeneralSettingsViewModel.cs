using DemoApp.Helpers;
using DemoApp.Models;
using DemoApp.Mvvm.ViewModel;
using DemoApp.Settings;
using System.Collections.ObjectModel;
using System.Globalization;

namespace DemoApp.ViewModels.Settings
{
    public class GeneralSettingsViewModel : ObservableObject
    {
        private readonly IUserSettings _userSettings;

        public GeneralSettingsViewModel(IUserSettings userSettings)
        {
            _userSettings = userSettings;

            LanguageCollection = new ObservableCollection<LanguageInfo>(Constants.Languages);
            SelectedLanguage =
                Constants.Languages.FirstOrDefault(lang => lang.Code.Equals(userSettings.Language)) ?? Constants.Languages[0];

            LocalizationSource.Instance.CurrentCulture = new CultureInfo(userSettings.Language);
        }

        public ObservableCollection<LanguageInfo> LanguageCollection { get; }

        private LanguageInfo? _selectedLanguage;

        public LanguageInfo SelectedLanguage
        {
            get => _selectedLanguage ?? Constants.Languages[0];
            set
            {
                if (_selectedLanguage == value)
                    return;

                var index = Array.FindIndex(Constants.Languages, lang => lang.FullName.Equals(value.FullName));

                if (index == -1) // TODO: Warning message?
                    return;

                LocalizationSource.Instance.CurrentCulture = new CultureInfo(Constants.Languages[index].Code);
                _userSettings.Language = Constants.Languages[index].Code;
                _selectedLanguage = value;
            }
        }
    }
}
