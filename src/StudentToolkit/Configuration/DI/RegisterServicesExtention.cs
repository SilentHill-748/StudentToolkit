namespace StudentToolkit.Configuration.DI;
public static class RegisterServicesExtention
{
    public static Container RegisterServices(this Container container)
    {
        container.RegisterSingleton<NavigationService>();
        container.RegisterSingleton<DataTemplateService>();

        return container;
    }
}
