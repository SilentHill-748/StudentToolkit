using System.Threading.Tasks;

namespace StudentToolkit.WpfCore.Commands.Base;

public abstract class AsyncCommand<T> : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool IsExecuting { get; set; }

    public abstract Task ExecuteAsync(T parameter);

    public virtual bool CanExecute(T parameter) => !IsExecuting;

    protected abstract Exception ConfigureException(Exception exception);

    bool ICommand.CanExecute(object? parameter) => CanExecute(CastParameter(parameter));

    async void ICommand.Execute(object? parameter)
    {
        IsExecuting = true;

        try
        {
            await ExecuteAsync(CastParameter(parameter));
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

    private static T CastParameter(object? parameter)
    {
        if (parameter is T p)
            return p;

        throw new ArgumentException($"Object parameter is null or is not generic type \'{typeof(T).Name}\'!", nameof(parameter));
    }
}
