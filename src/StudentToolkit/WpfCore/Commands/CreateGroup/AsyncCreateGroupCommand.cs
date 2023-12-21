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
        _viewModel.Group.GroupCode = _viewModel.GroupCode;

        await _groupStore.CreateGroupAsync(_viewModel.Group);

        NavigationService.Navigate<NavigationViewModel, MainViewModel>();
    }

    public override bool CanExecute()
    {
        return  !IsExecuting &&
                _viewModel.HasNoErrors && 
                _viewModel.Group.Students.Count > 5;
    }
}
