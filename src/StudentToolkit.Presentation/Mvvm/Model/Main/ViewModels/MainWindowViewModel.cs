namespace StudentToolkit.Presentation.Mvvm.Model.Main.ViewModels;

public class MainWindowViewModel : WindowViewModel
{
    public MainWindowViewModel(MainViewModel mainViewModel)
    {
        Title = TextConstants.DefaultWindowTitle;
        HostedViewModel = mainViewModel;
    }
}
