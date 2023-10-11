using StudentToolkit.MVVM.ViewModels.Components;

namespace StudentToolkit.MVVM.ViewModels;

public class MainViewModel : ViewModel, INavigatingViewModel
{
    private ViewModel? _content;

    public MainViewModel()
    {
        _content = new AboutViewModel();

        StatusBarViewModel = new StatusBarViewModel();
        WindowTitle = "Student Toolkit";
    }

    public StatusBarViewModel StatusBarViewModel { get; }

    public ViewModel? Content
    {
        get => _content;
        set => Set(ref _content, value);
    }
}
