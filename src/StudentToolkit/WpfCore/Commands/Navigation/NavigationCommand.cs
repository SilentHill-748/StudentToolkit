using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.Navigation;

public sealed class NavigationCommand<TSourceViewModel, TDestinationViewModel> : Command
    where TSourceViewModel : ViewModel 
    where TDestinationViewModel : ViewModel
{
    public override void Execute()
    {
        NavigationService.Navigate<TSourceViewModel, TDestinationViewModel>();
    }
}
