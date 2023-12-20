namespace StudentToolkit.Configuration.DI.Extentions;

public static class RegisterViewModelsExtention
{
    public static Container RegisterViewModels(this Container container)
    {
        container.RegisterSingleton<MainViewModel>();
        container.RegisterSingleton<NavigationViewModel>();
        container.Register<CreateGroupViewModel>();

        return container;
    }
}
