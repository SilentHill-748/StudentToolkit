namespace StudentToolkit.MVVM.Group.GroupInfo.ViewModels;

public class GroupNotFoundViewModel : ViewModel
{
    public GroupNotFoundViewModel()
    {
        NavigateToCreateGroupViewCommand = new NavigationCommand<MainViewModel, InputGroupDataViewModel>();
    }

    public ICommand NavigateToCreateGroupViewCommand { get; }
}
