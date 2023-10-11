namespace StudentToolkit.Configuration.DI;

public static class ConfigureServicesExtention
{
    public static Container RegisterWpfServices(this Container container)
    {
        container
            .RegisterServices()
            .RegisterViewModels()
            .RegisterViews();

        return container;
    }
}
