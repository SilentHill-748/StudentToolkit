using System.Threading.Tasks;

namespace StudentToolkit.WpfCore.Commands.Presentation.CreateGroup;

public sealed class AsyncCreateGroupCommand : AsyncCommand
{
    private const string GroupNotCreatedUserMessage = "Операция создания группы завершилась с ошибкой. Проверьте доступ к сети интернет или попробуйте повторить операцию позже.";

    private readonly CreateGroupViewModel _createGroupVm;
    private readonly IGroupStore _groupStore;

    public AsyncCreateGroupCommand(CreateGroupViewModel createGroupVm, IGroupStore groupStore)
    {
        _createGroupVm = createGroupVm;
        _groupStore = groupStore;
    }

    public override async Task ExecuteAsync()
    {
        _groupStore.Group.GroupCode = _createGroupVm.GroupCode;
        _groupStore.Group.Students = _createGroupVm.Students;

        await _groupStore.CreateGroupAsync();

        NavigationService.Navigate<NavigationViewModel, MainViewModel>();
    }

    public override bool CanExecute()
    {
        return !IsExecuting &&
                !_createGroupVm.HasErrors &&
                _createGroupVm.Students.Count > 5;
    }

    protected override Exception ConfigureException(Exception exception)
    {
        if (exception.IsWrapped())
        {
            return exception;
        }

        NotificationService.Alert("Error", GroupNotCreatedUserMessage);

        string commandClassName = GetType().Name;

        return exception
            .WrapWithMessage($"{commandClassName}: Student group isn't created.")
            .SetDetail("Group code", _createGroupVm.GroupCode)
            .SetDetail("Students count", _createGroupVm.Students.Count);
    }
}
