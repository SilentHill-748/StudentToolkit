using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class CreateGroupCommand : Command
{
    private readonly CreateGroupViewModel _viewModel;
    private readonly NavigationService _navigationService;

    public CreateGroupCommand(CreateGroupViewModel viewModel, NavigationService navigationService)
    {
        _viewModel = viewModel;
        _navigationService = navigationService;
    }

    public override void Execute()
    {
        var navigationQuery = new WindowNavigationQuery();

        _navigationService.NavigateTo<MainViewModel, WindowContentNavigationMessage>(navigationQuery);
    }
}
