using System.Threading.Tasks;

using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.Main;

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
