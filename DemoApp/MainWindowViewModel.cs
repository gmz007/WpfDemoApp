using DemoApp.Mvvm.ViewModelBase;
using System.Collections.ObjectModel;
using System.Globalization;
using DemoApp.Helpers;

namespace DemoApp
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Languages = new ObservableCollection<string>(_languages.Keys);
            CurrentLanguage = "English";
        }

        private readonly Dictionary<string, string> _languages = new()
        {
            { "Chinese (Simplified)", "zh-hans" },
            { "Chinese (Traditional)", "zh-hant" },
            { "English", "" },
            { "French", "fr" },
            { "Spanish", "es" },
        };

        public ObservableCollection<string> Languages { get; }

        private string _currentLanguage = string.Empty;

        public string CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                if (SetField(ref _currentLanguage, value))
                {
                    LocalizationSource.Instance.CurrentCulture = new CultureInfo(_languages[value]);
                }
            }
        }
    }
}
