using StudentToolkit.WpfCore.Commands.Navigation;

namespace StudentToolkit.MVVM.ViewModels.Presentation.GroupInfo;

public class GroupNotFoundViewModel : ViewModel
{
    public GroupNotFoundViewModel()
    {
        NavigateToCreateGroupViewCommand = new NavigationCommand<MainViewModel, CreateGroupViewModel>();
    }

    public ICommand NavigateToCreateGroupViewCommand { get; }
}
