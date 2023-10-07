using StudentToolkit.MVVM.ViewModels.Components;
using StudentToolkit.MVVM.ViewModels.Model;

namespace StudentToolkit.MVVM.ViewModels;

public class MainViewModel : ViewModel, INavigatingViewModel
{
    private ViewModel? _content;

    public MainViewModel()
    {
        _content = new AboutViewModel();

        StatusBarViewModel = new StatusBarViewModel(new GroupViewModel());
        WindowTitle = "Student Toolkit";
    }

    public StatusBarViewModel StatusBarViewModel { get; set; }

    public ViewModel? Content
    {
        get => _content;
        set => Set(ref _content, value);
    }
}
