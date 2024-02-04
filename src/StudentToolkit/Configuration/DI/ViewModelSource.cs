namespace StudentToolkit.Configuration.DI;

/// <summary>
/// The <see cref="ViewModel"/> objects locator.
/// </summary>
public static class ViewModelSource
{
    private static Func<Type, ViewModel>? ViewModelProvider;

    /// <summary>
    /// Set the <see cref="ViewModel"/> provider if it wasn't setted.
    /// </summary>
    /// <param name="viewModelProvider"> The ViewModel provider delegate.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void SetViewModelProvider(Func<Type, ViewModel> viewModelProvider)
    {
        ArgumentNullException.ThrowIfNull(viewModelProvider, nameof(viewModelProvider));

        ViewModelProvider ??= viewModelProvider;
    }

    /// <summary>
    /// Get instance of <typeparamref name="TViewModel"/>.
    /// </summary>
    /// <typeparam name="TViewModel">The type of view model.</typeparam>
    /// <returns>The <see cref="ViewModel"/> object that represents <typeparamref name="TViewModel"/> type.</returns>
    /// <exception cref="ViewModelProviderNotSetException"></exception>
    public static TViewModel Resolve<TViewModel>() where TViewModel : ViewModel
    {
        if (ViewModelProvider is null)
            throw new ViewModelProviderNotSetException($"The \'{nameof(ViewModelProvider)}\' is null!");

        return (TViewModel)ViewModelProvider(typeof(TViewModel));
    }
}
