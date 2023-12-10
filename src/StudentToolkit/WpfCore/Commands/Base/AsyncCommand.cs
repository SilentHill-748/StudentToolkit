using System.Threading.Tasks;

using StudentToolkit.WpfCore.Exceptions;

namespace StudentToolkit.WpfCore.Commands.Base;

public abstract class AsyncCommand(ILogger logger) 
    : ICommand
{
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

            logger.Debug($"The async command '{commandName}' is executed success.");
        }
        catch (Exception ex)
        {
            logger.Error(ex, $"An exception has occurred on executing process of async command '{commandName}'.");

            var message = CustomExceptionMessages.GetMessage(ex);

            NotificationService.Alert("Ошибка", message);
        }
        finally
        {
            IsExecuting = false;
        }
    }
}
