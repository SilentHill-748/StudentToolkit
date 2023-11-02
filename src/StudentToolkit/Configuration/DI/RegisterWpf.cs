using StudentToolkit.Configuration.DI.Extentions;

namespace StudentToolkit.Configuration.DI;

public static class RegisterWpf
{
    public static Container RegisterWpfServices(this Container container)
    {
        container
            .RegisterServices()
            .RegisterViewModels()
            .RegisterStores();

        return container;
    }
}
