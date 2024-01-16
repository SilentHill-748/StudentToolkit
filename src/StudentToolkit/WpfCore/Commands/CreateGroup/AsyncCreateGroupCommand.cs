using System.Threading.Tasks;

using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class AsyncCreateGroupCommand : AsyncCommand
{
    private readonly CreateGroupViewModel _createGroupVm;
    private readonly GroupStore _groupStore;

    public AsyncCreateGroupCommand(
        ILogger logger,
        CreateGroupViewModel createGroupVm,
        GroupStore groupStore)
            : base(logger)
    {
        _createGroupVm = createGroupVm;
        _groupStore = groupStore;
    }

    public override async Task ExecuteAsync()
    {
        var group = new GroupModel()
        {
            GroupCode = _createGroupVm.GroupCode,
            Students = _createGroupVm.Students
        };

        await _groupStore.CreateGroupAsync(group);

        NavigationService.Navigate<NavigationViewModel, MainViewModel>();
    }

    public override bool CanExecute()
    {
        return  !IsExecuting &&
                !_createGroupVm.HasErrors && 
                _createGroupVm.Students.Count > 5;
    }
}
