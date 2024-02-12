using StudentToolkit.WpfCore.Providers;

namespace StudentToolkit.Configuration.DI.Extentions;

public static class RegisterServicesExtension
{
    public static Container RegisterServices(this Container container)
    {
        container.RegisterSingleton<WindowsRegistryProvider>();

        return container;
    }
}
