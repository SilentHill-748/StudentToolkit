using System;

namespace StudentToolkit.WpfCore.Services;

internal class NavigationService
{
    private readonly Container _container;

    public NavigationService(Container container)
    {
        ArgumentNullException.ThrowIfNull(container, nameof(container));

        _container = container;
    }

    /// <summary>
    /// Do navigation to specified view.
    /// </summary>
    /// <typeparam name="TViewModel">The view model of specified view.</typeparam>
    public void NavigateToWindowView<TViewModel>()
        where TViewModel : ViewModel
    {
        NavigateTo<TViewModel>(typeof(WindowContentNavigationMessage));
    }

    /// <summary>
    /// Do navigation inside UI control to specified view.
    /// </summary>
    /// <typeparam name="TViewModel">The view model of specified view.</typeparam>
    public void NavigateToControlView<TViewModel>()
        where TViewModel : ViewModel
    {
        NavigateTo<TViewModel>(typeof(ControlContentNavigationMessage));
    }

    private void NavigateTo<TViewModel>(Type messageType)
        where TViewModel : ViewModel
    {
        ViewModel viewModel = _container.GetInstance<TViewModel>();

        var model = new NavigationModel(viewModel);

        var message = Activator.CreateInstance(messageType, model) ??
            throw new ArgumentException($"Cannot create instance the message of type '{messageType.Name}'!");

        WeakReferenceMessenger.Default.Send(message);
    }
}
