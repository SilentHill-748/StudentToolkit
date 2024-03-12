namespace StudentToolkit.MVVM.ViewModels.Presentation.Group.Info;

public class GroupHomePageViewModel : ViewModel
{
    private ViewModel _currentViewModel;

    public GroupHomePageViewModel(IGroupStore groupStore)
    {
        ArgumentNullException.ThrowIfNull(groupStore, nameof(groupStore));

        _currentViewModel = new GroupNotFoundViewModel();

        groupStore.GroupStoreChanged += OnGroupStoreChanged;
    }

    public ViewModel CurrentViewModel
    {
        get => _currentViewModel;
        set => Set(ref _currentViewModel, value);
    }

    private void OnGroupStoreChanged(GroupViewModel groupVm)
    {
        CurrentViewModel = groupVm.Id == Guid.Empty
            ? new GroupNotFoundViewModel()
            : new GroupInfoViewModel(groupVm);
    }
}
