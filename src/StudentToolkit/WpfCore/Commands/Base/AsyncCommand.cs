using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentToolkit.WpfCore.Commands.Base;

public abstract class AsyncCommand : ICommand
{
    private readonly Action<Exception> _exceptionHandler;
    private bool _isExecuting;

    public AsyncCommand(Action<Exception> exceptionHandler)
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

    public virtual bool CanExecute() => !IsExecuting;

    public abstract Task ExecuteAsync();

    bool ICommand.CanExecute(object? parameter) => CanExecute();

    async void ICommand.Execute(object? parameter)
    {
        try
        {
            IsExecuting = true;
            await ExecuteAsync();
        }
        catch (Exception ex)
        {
            _exceptionHandler?.Invoke(ex);
        }
        finally
        {
            IsExecuting = false;
        }
    }
}
