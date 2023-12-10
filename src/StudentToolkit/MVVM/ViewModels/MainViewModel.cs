namespace StudentToolkit.MVVM.ViewModels;

public class MainViewModel : ViewModel, INavigatingViewModel
{
    private ViewModel? _content;

    public MainViewModel(GroupStore groupStore)
    {
        _content = new AboutViewModel();

        StatusBarViewModel = new StatusBarViewModel();
        WindowTitle = "Student Toolkit";

        groupStore.Updated += OnStoreChanged;
        groupStore.Loaded += OnStoreChanged;
    }

    public StatusBarViewModel StatusBarViewModel { get; }

    public ViewModel? Content
    {
        get => _content;
        set => Set(ref _content, value);
    }

    public void OnStoreChanged(GroupViewModel groupVm)
    {
        StatusBarViewModel.GroupCode = groupVm.GroupCode;
    }
}
