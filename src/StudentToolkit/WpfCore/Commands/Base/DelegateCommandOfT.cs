namespace StudentToolkit.WpfCore.Commands.Base;

public class DelegateCommand<T> : Command<T>
{
    private readonly Action<T> _execute;
    private readonly Func<T, bool>? _canExecute;

    public DelegateCommand(Action<T> execute)
    {
        ArgumentNullException.ThrowIfNull(execute, nameof(execute));

        _execute = execute;
    }

    public DelegateCommand(Action<T> execute, Func<T, bool> canExecute) : this(execute)
    {
        ArgumentNullException.ThrowIfNull(canExecute, nameof(canExecute));

        _canExecute = canExecute;
    }

    public override void Execute(T parameter)
    {
        _execute(parameter);
    }

    public override bool CanExecute(T parameter)
    {
        return _canExecute is null || _canExecute(parameter);
    }
}
