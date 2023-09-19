using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentToolkit.WpfCore.Commands.Base;

public abstract class AsyncParameterizedCommand<T> : ICommand
{
    private readonly Action<Exception> _exceptionHandler;
    private bool _isExecuting;

    public AsyncParameterizedCommand(Action<Exception> exceptionHandler)
    {
        ArgumentNullException.ThrowIfNull(exceptionHandler, nameof(exceptionHandler));

        _exceptionHandler = exceptionHandler;
    }

    public event EventHandler? CanExecuteChanged;

    public bool IsExecuting
    {
        get => _isExecuting;
        set
        {
            _isExecuting = value;
            OnCanExecuteChanged();
        }
    }

    public void OnCanExecuteChanged()
        => CanExecuteChanged?.Invoke(this, new EventArgs());

    public abstract Task ExecuteAsync(T parameter);

    public virtual bool CanExecute(T parameter) => !IsExecuting;

    bool ICommand.CanExecute(object? parameter) => CanExecute(CastParameter(parameter));

    async void ICommand.Execute(object? parameter)
    {
        try
        {
            IsExecuting = true;
            await ExecuteAsync(CastParameter(parameter));
        }
        catch (Exception ex)
        {
            _exceptionHandler.Invoke(ex);
        }
        finally
        {
            IsExecuting = false;
        }
    }

    private static T CastParameter(object? parameter)
    {
        if (parameter is T p)
            return p;

        throw new ArgumentException($"Object parameter is null or is not generic type \'{typeof(T).Name}\'!", nameof(parameter));
    }
}
