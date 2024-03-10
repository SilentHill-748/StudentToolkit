using StudentToolkit.MVVM.ViewModels.Presentation.GroupInfo;

namespace StudentToolkit.MVVM.ViewModels;

public class MainViewModel : ViewModel
{
    private ViewModel? _contentViewModel;

    public MainViewModel(IGroupStore groupStore)
    {
        _contentViewModel = new GroupNotFoundViewModel();

        StatusBarViewModel = new StatusbarViewModel();
        WindowTitle = "Student Toolkit";

        LoadedEventCommand = new AsyncMainViewLoadedCommand(groupStore);
        NavigateToGroupInfoViewCommand = new NavigationCommand<MainViewModel, GroupNotFoundViewModel>();
        NavigateToAboutViewCommand = new NavigationCommand<MainViewModel, AboutViewModel>();

        groupStore.GroupStoreChanged += OnStoreChanged;

        WeakReferenceMessenger.Default.Register<NavigationMessage>(this, (recipient, message) =>
        {
            ContentViewModel = message.GetDestinationViewModel<MainViewModel>() ?? ContentViewModel;
        });
    }

    public StatusbarViewModel StatusBarViewModel { get; }

    public ViewModel? ContentViewModel
    {
        get => _contentViewModel;
        set => Set(ref _contentViewModel, value);
    }

    public ICommand LoadedEventCommand { get; }
    public ICommand NavigateToGroupInfoViewCommand { get; }
    public ICommand NavigateToAboutViewCommand { get; }

    private void OnStoreChanged(GroupViewModel groupVm)
    {
        StatusBarViewModel.GroupCode = groupVm.GroupCode;
    }
}
