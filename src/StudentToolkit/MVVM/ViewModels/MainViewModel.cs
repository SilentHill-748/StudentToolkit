namespace StudentToolkit.MVVM.ViewModels;

public class MainViewModel : ViewModel
{
    private ViewModel _currentViewMdoel;

    public MainViewModel(ViewModel defaultViewModel)
    {
        _currentViewMdoel = defaultViewModel;

        WeakReferenceMessenger.Default.Register<WindowContentNavigationMessage>(this, OnNavigated);
    }

    public ViewModel CurrentViewModel
    {
        get => _currentViewMdoel;
        set => Set(ref _currentViewMdoel, value);
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
