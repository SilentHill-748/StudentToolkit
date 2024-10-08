﻿namespace StudentToolkit.Presentation.Common.Abstractions.Commands;

public abstract class Command : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public virtual bool CanExecute() => true;

    public abstract void Execute();

    public void RaiseCanExecuteChanged()
        => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    #region ICommand
    bool ICommand.CanExecute(object? parameter)
        => CanExecute();

    void ICommand.Execute(object? parameter)
        => Execute();
    #endregion
}
