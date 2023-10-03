namespace StudentToolkit.Configuration.DI;

public static class ConfigureServicesExtention
{
    public static void ConfigureServices(this Container container)
    {
        container
            .RegisterServices()
            .RegisterLogger()
            .RegisterViewModels()
            .RegisterViews();

        container.Verify();
    }
}
