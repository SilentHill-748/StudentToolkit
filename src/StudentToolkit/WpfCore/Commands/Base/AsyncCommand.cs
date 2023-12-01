using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentToolkit.WpfCore.Commands.Base;

public abstract class AsyncCommand : ICommand
{
    private readonly ILogger _logger;

    public AsyncCommand(ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));

        _logger = logger;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool IsExecuting { get; set; }

    public virtual bool CanExecute() => !IsExecuting;

    public abstract Task ExecuteAsync();

    bool ICommand.CanExecute(object? parameter) => CanExecute();

    async void ICommand.Execute(object? parameter)
    {
        var commandName = GetType().Name;

        try
        {
            IsExecuting = true;
            
            await ExecuteAsync();

            _logger.Debug($"The async command '{commandName}' is executed success.");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, $"An exception has occurred on executing process of async command '{commandName}'.");
            throw;
        }
        finally
        {
            IsExecuting = false;
        }
    }
}
