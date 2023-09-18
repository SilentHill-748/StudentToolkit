namespace StudentToolkit.Configuration.DI;

public static class RegisterServicesExtention
{
    public static void RegisterServices(this Container container)
    {
        container
            .RegisterViewModels()
            .RegisterViews();

        container.Verify();
    }
}
