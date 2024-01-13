namespace StudentToolkit.WpfCore.Services;

public static class NavigationService
{
    /// <summary>
    /// Begin navigation to <typeparamref name="TDestinationViewModel"/> into <typeparamref name="TSourceViewModel"/>.
    /// </summary>
    /// <typeparam name="TSourceViewModel">The view model which contains content view that need changed.</typeparam>
    /// <typeparam name="TDestinationViewModel">The view model that must change previous view model.</typeparam>
    public static void Navigate<TSourceViewModel, TDestinationViewModel>()
        where TSourceViewModel : ViewModel
        where TDestinationViewModel : ViewModel
    {
        var destinationVm = ViewModelSource.Resolve<TDestinationViewModel>();

        SendNavigationMessage<TSourceViewModel>(destinationVm);
    }

    /// <summary>
    /// Begin navigation to specified view model into <typeparamref name="TSourceViewModel"/>.
    /// </summary>
    /// <typeparam name="TSourceViewModel">The view model which contains content view that need changed.</typeparam>
    /// <param name="destinationVm">The view model that must change previous view model.</param>
    public static void Navigate<TSourceViewModel>(ViewModel destinationVm)
    {
        ArgumentNullException.ThrowIfNull(destinationVm, nameof(destinationVm));

        SendNavigationMessage<TSourceViewModel>(destinationVm);
    }

    private static void SendNavigationMessage<TSourceViewModel>(ViewModel destinationVm)
    {
        var message = 
            new NavigationMessage(
                new NavigationModel(destinationVm, typeof(TSourceViewModel)));

        WeakReferenceMessenger.Default.Send(message);
    }
}
