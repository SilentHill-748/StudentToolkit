using System.Threading.Tasks;

using StudentToolkit.MVVM.ViewModels.Presentation.GroupInfo;

namespace StudentToolkit.WpfCore.Commands.Presentation.Group;

public sealed class AsyncCreateGroupCommand : AsyncCommand
{
    private const string GroupNotCreatedUserMessage = "Операция создания группы завершилась с ошибкой. Проверьте доступ к сети интернет или попробуйте повторить операцию позже.";
    private const string ExceptionLogMessage = "Occured an exception in creating the group of students process.";

    private readonly AddStudentsToGroupViewModel _createGroupVm;
    private readonly IGroupStore _groupStore;

    public AsyncCreateGroupCommand(
        AddStudentsToGroupViewModel createGroupVm,
        IGroupStore groupStore)
    {
        _createGroupVm = createGroupVm;
        _groupStore = groupStore;
    }

    public override async Task ExecuteAsync()
    {
        _groupStore.Group.Students = _createGroupVm.Students.Adapt<ObservableCollection<StudentViewModel>>();

        await _groupStore.CreateGroupAsync();

        NavigationService.Navigate<MainViewModel, GroupNotFoundViewModel>();
    }

    public override bool CanExecute()
        => IsValidStudentsCountAndNotExecuting();

    protected override Exception ConfigureException(Exception exception)
    {
        NotificationService.Alert("Error", GroupNotCreatedUserMessage);

        GroupViewModel filligByUserGroupData = _groupStore.Group;

        return exception
            .WrapWithMessage(ExceptionLogMessage)
            .SetDetail("Group code", filligByUserGroupData.GroupCode)
            .SetDetail("Students count", filligByUserGroupData.Students.Count);
    }

    private bool IsValidStudentsCountAndNotExecuting()
    {
        return
            IsValidStudentCount() &&
            IsNotExecuting();
    }

    private bool IsValidStudentCount()
        => _createGroupVm.Students.Count > 5;

    private bool IsNotExecuting()
        => !IsExecuting;
}
