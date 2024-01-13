namespace StudentToolkit.Configuration.DI;

/// <summary>
/// The <see cref="ViewModel"/> objects locator.
/// </summary>
public static class ViewModelSource
{
    /// <summary>
    /// The <see cref="ViewModel"/> provider delegate.
    /// </summary>
    public static Func<Type, ViewModel>? Provider { get; set; }

    /// <summary>
    /// Get instance of <typeparamref name="TViewModel"/>.
    /// </summary>
    /// <typeparam name="TViewModel">The type of view model.</typeparam>
    /// <returns>The <see cref="ViewModel"/> object that represents <typeparamref name="TViewModel"/> type.</returns>
    /// <exception cref="ViewModelProviderNotSetException"></exception>
    public static TViewModel Resolve<TViewModel>() where TViewModel : ViewModel
    {
        if (Provider is null)
            throw new ViewModelProviderNotSetException();

        return (TViewModel)Provider(typeof(TViewModel));
    }
}
