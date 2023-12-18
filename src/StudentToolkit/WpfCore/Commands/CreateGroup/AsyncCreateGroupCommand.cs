using System.Threading.Tasks;

using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class AsyncCreateGroupCommand(
    ILogger logger,
    CreateGroupViewModel viewModel,
    GroupStore groupStore) 
        : AsyncCommand(logger)
{
    public override async Task ExecuteAsync()
    {
        viewModel.Group.GroupCode = viewModel.GroupCode;

        await groupStore.CreateGroupAsync(viewModel.Group);

        NavigationService.Navigate<NavigationViewModel, MainViewModel>();
    }

    public override bool CanExecute()
    {
        return  !IsExecuting &&
                viewModel.HasNoErrors && 
                viewModel.Group.Students.Count > 5;
    }
}
