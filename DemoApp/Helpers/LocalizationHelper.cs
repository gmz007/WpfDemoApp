using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Windows.Data;

namespace DemoApp.Helpers
{
    public class Localization : Binding
    {
        public Localization(string name) : base($"[{name}]")
        {
            Mode = BindingMode.OneWay;
            Source = LocalizationSource.Instance;
        }
    }

    public class LocalizationSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public static LocalizationSource Instance { get; } = new();

        public string? this[string key] => _resourceManger.GetString(key, CurrentCulture);

        private readonly ResourceManager _resourceManger = DemoApp.Localization.Resources.ResourceManager;

        private CultureInfo _currentCulture = new("");

        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (_currentCulture.Name == value.Name)
                    return;

                _currentCulture = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
            }
        }
    }
}
