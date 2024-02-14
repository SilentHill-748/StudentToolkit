using System.Threading.Tasks;

namespace StudentToolkit.WpfCore.Commands.Presentation.Main;

public class AsyncMainViewLoadedCommand : AsyncCommand
{
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
        // GroupStore will handle this exception.
        return exception;
    }
}
