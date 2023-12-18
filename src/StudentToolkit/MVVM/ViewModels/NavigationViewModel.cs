namespace StudentToolkit.MVVM.ViewModels;

public class NavigationViewModel : ViewModel
{
    private ViewModel? _currentViewModel;

    public NavigationViewModel()
    {
        WeakReferenceMessenger.Default.Register<NavigationMessage>(this, (recipient, message) =>
        {
            CurrentViewModel = message.GetDestinationViewModel<NavigationViewModel>() ?? CurrentViewModel;
        });
    }

    public ViewModel? CurrentViewModel
    {
        get => _currentViewModel;
        set => Set(ref _currentViewModel, value);
    }
}
