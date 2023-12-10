using StudentToolkit.WpfCore.Providers;

namespace StudentToolkit.Configuration.DI.Extentions;

public static class RegisterServicesExtention
{
    public static Container RegisterServices(this Container container)
    {
        container.RegisterSingleton<WindowsRegistryProvider>();
        container.RegisterSingleton<NavigationService>();
        container.RegisterSingleton<Func<Type, object>>(() => container.GetInstance);

        return container;
    }
}
