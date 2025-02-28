namespace DemoApp.Mvvm.RelayCommand
{
    public class RelayCommand : IRelayCommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly Action<object?> _execute;
        private readonly Predicate<object?>? _canExecute;

        public RelayCommand(Predicate<object?> canExecute, Action<object?> execute) : this(execute)
        {
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object?> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
