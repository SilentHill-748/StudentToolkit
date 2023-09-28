namespace StudentToolkit.MVVM.Models.Navigation;

public sealed class NavigationModel
{
    public NavigationModel(ViewModel viewModel)
    {
        DestinationViewModel = viewModel;
    }

    public ViewModel DestinationViewModel { get; set; }
}
