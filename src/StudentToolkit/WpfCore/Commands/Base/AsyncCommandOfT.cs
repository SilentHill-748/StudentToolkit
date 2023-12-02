using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentToolkit.WpfCore.Commands.Base;

public abstract class AsyncCommand<T> : ICommand
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

    public abstract Task ExecuteAsync(T parameter);

    public virtual bool CanExecute(T parameter) => !IsExecuting;

    bool ICommand.CanExecute(object? parameter) => CanExecute(CastParameter(parameter));

    async void ICommand.Execute(object? parameter)
    {
        var commandName = GetType().Name;

        try
        {
            IsExecuting = true;
            await ExecuteAsync(CastParameter(parameter));

            _logger.Debug($"The generic async command '{commandName}' is executed success.");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, $"An exception has occurred on executing process of generic async command '{commandName}'.");

            DialogService.ShowNotification(
                "Ошибка",
                "При выполнении операции произошла ошибка. Попробуйте выполнить действие позже.",
                NotificationIcon.Error);
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
