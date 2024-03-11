namespace StudentToolkit.MVVM.ViewModels.Presentation.Group.Info;

public class GroupNotFoundViewModel : ViewModel
{
    public GroupNotFoundViewModel()
    {
        NavigateToCreateGroupViewCommand = new NavigationCommand<MainViewModel, InputGroupDataViewModel>();
    }

    public ICommand NavigateToCreateGroupViewCommand { get; }
}
