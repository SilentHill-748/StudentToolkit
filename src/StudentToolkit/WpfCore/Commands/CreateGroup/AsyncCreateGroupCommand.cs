using System.Threading.Tasks;

using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class AsyncCreateGroupCommand : AsyncCommand
{
    private const string GroupNotCreatedUserMessage = "Операция создания группы завершилась с ошибкой. Проверьте доступ к сети интернет или попробуйте повторить операцию позже.";

    private readonly CreateGroupViewModel _createGroupVm;
    private readonly GroupStore _groupStore;

    public AsyncCreateGroupCommand(CreateGroupViewModel createGroupVm, GroupStore groupStore)
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

    protected override Exception ConfigureException(Exception exception)
    {
        NotificationService.Alert("Error", GroupNotCreatedUserMessage);

        string commandClassName = this.GetType().Name;

        return exception
            .WrapWithMessage($"{commandClassName}: Student group isn't created.")
            .SetDetail("Group code", _createGroupVm.GroupCode)
            .SetDetail("Students count", _createGroupVm.Students.Count);
    }
}
