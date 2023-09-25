namespace StudentToolkit.MVVM.Models.Navigation;

internal sealed class NavigationModel
{
    public NavigationModel(ViewModel viewModel)
    {
        DestinationViewModel = viewModel;
    }

    public ViewModel DestinationViewModel { get; set; }
}
