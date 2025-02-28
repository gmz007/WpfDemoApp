namespace DemoApp.Mvvm.RelayCommand
{
    public class RelayCommand<T> : IRelayCommand<T>
    {
        public event EventHandler? CanExecuteChanged;

        private readonly Action<T?> _execute;
        private readonly Predicate<T?>? _canExecute;

        public RelayCommand(Predicate<T?> canExecute, Action<T?> execute) : this(execute)
        {
            _canExecute = canExecute;
        }

        public RelayCommand(Action<T?> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(T? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(T? parameter)
        {
            _execute.Invoke(parameter);
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is not T type)
                throw new Exception();  // TODO: Add custom exceptions

            return _canExecute?.Invoke(type) ?? true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is not T type)
                throw new Exception();  // TODO: Add custom exceptions

            _execute.Invoke(type);
        }
    }
}
