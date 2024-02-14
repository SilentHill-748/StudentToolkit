using System.Threading.Tasks;

namespace StudentToolkit.WpfCore.Commands.Base;

public abstract class AsyncCommand : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool IsExecuting { get; set; }

    public virtual bool CanExecute() => !IsExecuting;

    public abstract Task ExecuteAsync();

    protected abstract Exception ConfigureException(Exception exception);

    bool ICommand.CanExecute(object? parameter) => CanExecute();

    async void ICommand.Execute(object? parameter)
    {
        IsExecuting = true;

        try
        {
            await ExecuteAsync();
        }
        catch (DataWrapperException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw ConfigureException(ex);
        }
        finally
        {
            IsExecuting = false;
        }
    }
}
