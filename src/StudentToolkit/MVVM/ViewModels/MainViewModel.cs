namespace StudentToolkit.MVVM.ViewModels;

public class MainViewModel : ViewModel
{
    private ViewModel? _content;

    public MainViewModel(GroupStore groupStore)
    {
        _content = new AboutViewModel();

        StatusBarViewModel = new StatusBarViewModel();
        WindowTitle = "Student Toolkit";

        groupStore.Updated += OnStoreChanged;
        groupStore.Loaded += OnStoreChanged;

        WeakReferenceMessenger.Default.Register<NavigationMessage>(this, (recipient, message) =>
        {
            Content = message.GetDestinationViewModel<MainViewModel>() ?? Content;
        });
    }

    public StatusBarViewModel StatusBarViewModel { get; }

    public ViewModel? Content
    {
        get => _content;
        set => Set(ref _content, value);
    }

    private void OnStoreChanged(GroupViewModel groupVm)
    {
        StatusBarViewModel.GroupCode = groupVm.GroupCode;
    }
}
