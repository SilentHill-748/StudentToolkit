using System.Threading.Tasks;

using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class AsyncCreateGroupCommand : AsyncCommand
{
    private readonly CreateGroupViewModel _viewModel;
    private readonly GroupStore _groupStore;

    public AsyncCreateGroupCommand(
        ILogger logger,
        CreateGroupViewModel viewModel,
        GroupStore groupStore)
            : base(logger)
    {
        _viewModel = viewModel;
        _groupStore = groupStore;
    }

    public override async Task ExecuteAsync()
    {
        var group = new GroupModel()
        {
            GroupCode = _viewModel.GroupCode,
            Students = _viewModel.Students
        };

        await _groupStore.CreateGroupAsync(group);

        NavigationService.Navigate<NavigationViewModel, MainViewModel>();
    }

    public override bool CanExecute()
    {
        return  !IsExecuting &&
                _viewModel.HasNoErrors && 
                _viewModel.Students.Count > 5;
    }
}
