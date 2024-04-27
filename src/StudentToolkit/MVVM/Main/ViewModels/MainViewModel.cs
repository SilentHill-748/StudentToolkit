using StudentToolkit.MVVM.About.ViewModels;

namespace StudentToolkit.MVVM.Main.ViewModels;

public class MainViewModel : ViewModel
{
    private ViewModel? _contentViewModel;

    public MainViewModel(IGroupStore groupStore)
    {
        StatusbarViewModel = new StatusbarViewModel();
        WindowTitle = "Student Toolkit";

        LoadedEventCommand = new AsyncMainViewLoadedCommand(groupStore);
        NavigateToGroupHomePageCommand = new NavigationCommand<MainViewModel, GroupHomePageViewModel>();
        NavigateToAboutViewCommand = new NavigationCommand<MainViewModel, AboutViewModel>();

        groupStore.GroupStoreChanged += OnStoreChanged;

        WeakReferenceMessenger.Default.Register<NavigationMessage>(this, (recipient, message) =>
        {
            ContentViewModel = message.GetDestinationViewModel<MainViewModel>() ?? ContentViewModel;
        });
    }

    public StatusbarViewModel StatusbarViewModel { get; }

    public ViewModel? ContentViewModel
    {
        get => _contentViewModel;
        set => Set(ref _contentViewModel, value);
    }

    public ICommand LoadedEventCommand { get; }
    public ICommand NavigateToGroupHomePageCommand { get; }
    public ICommand NavigateToAboutViewCommand { get; }

    private void OnStoreChanged(GroupViewModel groupVm)
    {
        StatusbarViewModel.GroupCode = groupVm.GroupCode;
    }
}
