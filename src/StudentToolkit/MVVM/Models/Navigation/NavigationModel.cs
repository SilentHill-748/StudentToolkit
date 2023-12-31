namespace StudentToolkit.MVVM.Models.Navigation;

public sealed class NavigationModel
{
    public NavigationModel(ViewModel destinationVm, Type sourceVmType)
    {
        ArgumentNullException.ThrowIfNull(destinationVm, nameof(destinationVm));
        ArgumentNullException.ThrowIfNull(sourceVmType, nameof(sourceVmType));

        DestinationViewModel = destinationVm;
        SourceViewModelType = sourceVmType;
    }

    public ViewModel DestinationViewModel { get; }
    public Type SourceViewModelType { get; }
}
