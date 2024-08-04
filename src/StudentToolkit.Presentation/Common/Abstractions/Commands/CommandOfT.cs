namespace StudentToolkit.Presentation.Common.Abstractions.Commands;

public abstract class Command<T> : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public virtual bool CanExecute(T parameter) => true;

    public abstract void Execute(T parameter);

    public void RaiseCanExecuteChanged()
        => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    #region ICommand
    bool ICommand.CanExecute(object? parameter)
        => CanExecute(
            TransformParameter(parameter));

    void ICommand.Execute(object? parameter)
        => Execute(
            TransformParameter(parameter));
    #endregion

    private static T TransformParameter(object? parameter)
    {
        if (parameter is T parameterizedParameter)
            return parameterizedParameter;

        throw new BadCommandParameterException(typeof(T));
    }
}
