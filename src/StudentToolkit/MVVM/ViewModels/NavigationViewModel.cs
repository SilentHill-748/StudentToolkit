namespace StudentToolkit.MVVM.ViewModels;

public class NavigationViewModel : ViewModel
{
    private ViewModel _currentViewModel;

    public NavigationViewModel(ViewModel defaultViewModel)
    {
        _currentViewModel = defaultViewModel;

        WeakReferenceMessenger.Default.Register<WindowContentNavigationMessage>(this, OnNavigated);
    }

    public ViewModel CurrentViewModel
    {
        get => _currentViewModel;
        set => Set(ref _currentViewModel, value);
    }

    private void OnNavigated(object recipient, WindowContentNavigationMessage message)
    {
        if (message.Value is NavigationModel model)
        {
            CurrentViewModel = model.DestinationViewModel;

            WindowTitle = model.DestinationViewModel.WindowTitle;
        }
    }
}
