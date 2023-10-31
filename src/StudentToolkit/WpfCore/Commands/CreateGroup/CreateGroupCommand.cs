using System.Threading.Tasks;

using StudentToolkit.MVVM.Stores;
using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class CreateGroupCommand : AsyncCommand
{
    private readonly CreateGroupViewModel _viewModel;
    private readonly GroupStore _groupStore;
    private readonly NavigationService _navigationService;

    public CreateGroupCommand(
        ILogger logger,
        CreateGroupViewModel viewModel,
        GroupStore groupStore,
        NavigationService navigationService) : base(logger)
    {
        _viewModel = viewModel;
        _groupStore = groupStore;
        _navigationService = navigationService;
    }

    public override async Task ExecuteAsync()
    {
        await _groupStore.CreateGroupAsync(_viewModel.Group);

        var navigationQuery = new WindowNavigationQuery();

        _navigationService.NavigateTo<MainViewModel, WindowContentNavigationMessage>(navigationQuery);
    }

    public override bool CanExecute()
    {
        return  !IsExecuting &&
                _viewModel.HasNoErrors && 
                _viewModel.Group.Students.Count > 5;
    }
}
