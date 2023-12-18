namespace StudentToolkit.Configuration.DI;

/// <summary>
/// The <see cref="ViewModel"/> objects locator.
/// </summary>
public class ViewModelSource
{
    private static ViewModelSource? LocalInstance;
    private static readonly object LockObject = new();

    /// <summary>
    /// The thread-safe singleton instance of <see cref="ViewModelSource"/>.
    /// </summary>
    public static ViewModelSource Instance
    {
        get
        {
            if (LocalInstance is null)
            {
                lock (LockObject)
                {
                    LocalInstance ??= new ViewModelSource();
                }
            }

            return LocalInstance;
        }
    }

    /// <summary>
    /// The <see cref="ViewModel"/> provider delegate.
    /// </summary>
    public Func<Type, ViewModel>? Provider { get; set; }

    /// <summary>
    /// Get instance of <typeparamref name="TViewModel"/>.
    /// </summary>
    /// <typeparam name="TViewModel">The type of view model.</typeparam>
    /// <returns>The <see cref="ViewModel"/> object that represents <typeparamref name="TViewModel"/> type.</returns>
    /// <exception cref="ViewModelProviderNotSetException"></exception>
    public TViewModel Resolve<TViewModel>() where TViewModel : ViewModel
    {
        if (Provider is null)
            throw new ViewModelProviderNotSetException();

        return (TViewModel)Provider(typeof(TViewModel));
    }
}
