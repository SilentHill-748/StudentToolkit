namespace StudentToolkit.WpfCore.Commands.Base;

public abstract class Command : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public abstract void Execute();

    public virtual bool CanExecute() => true;
    
    bool ICommand.CanExecute(object? parameter) => CanExecute();
    
    void ICommand.Execute(object? parameter) => Execute();
}
