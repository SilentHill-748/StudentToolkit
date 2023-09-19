using System;
using System.Windows.Input;

namespace StudentToolkit.WpfCore.Commands.Base;

public abstract class ParameterizedCommand<T> : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public abstract void Execute(T parameter);

    public virtual bool CanExecute(T parameter) => true;

    public void OnCanExecuteChanged()
        => CanExecuteChanged?.Invoke(this, new EventArgs());

    bool ICommand.CanExecute(object? parameter)
    {
        return parameter is null || CanExecute(CastParameter(parameter));
    }

    void ICommand.Execute(object? parameter) => Execute(CastParameter(parameter));

    private static T CastParameter(object? parameter)
    {
        if (parameter is T p)
            return p;

        throw new ArgumentException($"Object parameter is null or is not generic type \'{typeof(T).Name}\'!", nameof(parameter));
    }
}
