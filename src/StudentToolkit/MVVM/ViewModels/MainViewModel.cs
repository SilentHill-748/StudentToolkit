using StudentToolkit.MVVM.ViewModels.Presentation.GroupInfo;

namespace StudentToolkit.MVVM.ViewModels;

public class MainViewModel : ViewModel
{
    private ViewModel? _contentViewModel;

    public MainViewModel(IGroupStore groupStore)
    {
        _contentViewModel = new GroupNotFoundViewModel();

        StatusBarViewModel = new StatusBarViewModel();
        WindowTitle = "Student Toolkit";

        LoadedEventCommand = new AsyncMainViewLoadedCommand(groupStore);

        groupStore.GroupStoreChanged += OnStoreChanged;

        WeakReferenceMessenger.Default.Register<NavigationMessage>(this, (recipient, message) =>
        {
            ContentViewModel = message.GetDestinationViewModel<MainViewModel>() ?? ContentViewModel;
        });
    }

    public StatusBarViewModel StatusBarViewModel { get; }

    public ViewModel? ContentViewModel
    {
        get => _contentViewModel;
        set => Set(ref _contentViewModel, value);
    }

    public ICommand LoadedEventCommand { get; }

    private void OnStoreChanged(GroupModel groupVm)
    {
        StatusBarViewModel.GroupCode = groupVm.GroupCode;
    }
}
