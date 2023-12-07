namespace StudentToolkit.MVVM.Models.Navigation;

public sealed class NavigationModel(ViewModel viewModel)
{
    public ViewModel DestinationViewModel => viewModel;
}
