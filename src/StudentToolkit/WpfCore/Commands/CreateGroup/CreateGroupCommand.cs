using System.Threading.Tasks;

using StudentToolkit.MVVM.Stores;
using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class CreateGroupCommand(
    ILogger _logger,
    CreateGroupViewModel _viewModel,
    GroupStore _groupStore,
    NavigationService _navigationService) 
        : AsyncCommand(_logger)
{
    public override async Task ExecuteAsync()
    {
        _viewModel.Group.GroupCode = _viewModel.GroupCode;

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
