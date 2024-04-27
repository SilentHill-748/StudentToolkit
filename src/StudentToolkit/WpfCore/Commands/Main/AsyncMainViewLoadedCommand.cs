using System.Threading.Tasks;

namespace StudentToolkit.WpfCore.Commands.Main;

public class AsyncMainViewLoadedCommand : AsyncCommand
{
    private const string ExceptionLogMessage = "Loading of MainView at async command was stopped by an exception.";

    private readonly IGroupStore _groupStore;

    public AsyncMainViewLoadedCommand(IGroupStore groupStore)
    {
        _groupStore = groupStore;
    }

    public override async Task ExecuteAsync()
    {
        await _groupStore.LoadAsync();
    }

    protected override Exception ConfigureException(Exception exception)
    {
        return exception.WrapWithMessage(ExceptionLogMessage);
    }
}
