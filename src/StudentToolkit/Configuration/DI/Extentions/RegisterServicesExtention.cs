using StudentToolkit.WpfCore.Providers;

namespace StudentToolkit.Configuration.DI.Extentions;

public static class RegisterServicesExtention
{
    public static Container RegisterServices(this Container container)
    {
        container.RegisterSingleton<WindowsRegistryProvider>();

        return container;
    }
}
