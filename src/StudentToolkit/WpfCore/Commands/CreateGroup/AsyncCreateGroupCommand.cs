using System.Threading.Tasks;

using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class AsyncCreateGroupCommand(
    ILogger logger,
    CreateGroupViewModel viewModel,
    GroupStore groupStore,
    NavigationService navigationService) 
        : AsyncCommand(logger)
{
    public override async Task ExecuteAsync()
    {
        viewModel.Group.GroupCode = viewModel.GroupCode;

        await groupStore.CreateGroupAsync(viewModel.Group);

        var navigationQuery = new WindowNavigationQuery();

        navigationService.NavigateTo<MainViewModel, WindowContentNavigationMessage>(navigationQuery);
    }

    public override bool CanExecute()
    {
        return  !IsExecuting &&
                viewModel.HasNoErrors && 
                viewModel.Group.Students.Count > 5;
    }
}
