using System;
using System.Windows.Input;

namespace StudentToolkit.WpfCore.Commands.Base;

public abstract class Command : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public abstract void Execute();

    public virtual bool CanExecute() => true;

    public virtual void OnCanExecuteChanged()
        => CanExecuteChanged?.Invoke(this, new EventArgs());
    
    bool ICommand.CanExecute(object? parameter) => CanExecute();
    
    void ICommand.Execute(object? parameter) => Execute();
}
