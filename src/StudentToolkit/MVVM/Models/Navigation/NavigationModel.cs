namespace StudentToolkit.MVVM.Models.Navigation;

public sealed class NavigationModel(ViewModel _viewModel)
{
    public ViewModel DestinationViewModel => _viewModel;
}
