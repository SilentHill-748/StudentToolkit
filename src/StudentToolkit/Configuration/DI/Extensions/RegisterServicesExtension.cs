using StudentToolkit.WpfCore.Providers;

namespace StudentToolkit.Configuration.DI.Extensions;

public static class RegisterServicesExtension
{
    public static Container RegisterServices(this Container container)
    {
        container.RegisterSingleton<WindowsRegistryProvider>();

        return container;
    }
}
