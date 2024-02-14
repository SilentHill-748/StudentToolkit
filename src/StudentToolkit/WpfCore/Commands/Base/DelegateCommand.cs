namespace StudentToolkit.WpfCore.Commands.Base;

public class DelegateCommand : Command
{
    private readonly Action _execute;
    private readonly Func<bool>? _canExecute;

    public DelegateCommand(Action execute)
    {
        ArgumentNullException.ThrowIfNull(execute, nameof(execute));

        _execute = execute;
    }

    public DelegateCommand(Action execute, Func<bool> canExecute) : this(execute)
    {
        ArgumentNullException.ThrowIfNull(canExecute, nameof(canExecute));

        _canExecute = canExecute;
    }

    public override void Execute()
    {
        _execute();
    }

    public override bool CanExecute()
    {
        return _canExecute is null || _canExecute();
    }
}
