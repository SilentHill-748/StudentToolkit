namespace StudentToolkit.MVVM.Models.Navigation;

public sealed class NavigationModel(ViewModel destinationVm, Type sourceVmType)
{
    public ViewModel DestinationViewModel => destinationVm;
    public Type SourceViewModelType => sourceVmType;
}
