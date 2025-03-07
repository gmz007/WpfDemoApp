using DemoApp.Mvvm.RelayCommand;
using DemoApp.Mvvm.ViewModel;

namespace DemoApp.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private string _searchText = string.Empty;

        public string SearchText
        {
            get => _searchText;
            set => SetField(ref _searchText, value);
        }

        private IRelayCommand? _searchButtonCommand;

        public IRelayCommand SearchButtonCommand
        {
            get => _searchButtonCommand ??= new RelayCommand(
                _ =>
                {
                    Console.Write(SearchText);
                });
        }
    }
}
