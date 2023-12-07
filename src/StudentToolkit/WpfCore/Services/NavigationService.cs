namespace StudentToolkit.WpfCore.Services;

public class NavigationService(Func<Type, object> viewModelResolver)
{
    /// <summary>
    /// Do navigation to specified view by her view model.
    /// </summary>
    /// <typeparam name="TViewModel">The navigating view model type.</typeparam>
    /// <typeparam name="TMessage">The navigation message type.</typeparam>
    /// <param name="navigationQuery">Query for generating navigation message.</param>
    /// <exception cref="NavigationDeniedException"></exception>
    public void NavigateTo<TViewModel, TMessage>(NavigationQuery<TMessage> navigationQuery)
        where TViewModel : ViewModel
        where TMessage : ValueChangedMessage<NavigationModel>
    {
        var viewModel = (TViewModel)viewModelResolver(typeof(TViewModel));

        if (viewModel is not INavigatingViewModel)
            throw new NavigationDeniedException($"Navigation view model '{typeof(TViewModel).Name}' cannot be use for navigation!");

        var message = navigationQuery.Execute(viewModel);

        WeakReferenceMessenger.Default.Send(message);
    }
}
