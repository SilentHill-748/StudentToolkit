namespace StudentToolkit.Configuration.DI.Extensions;

public static class RegisterViewModelsExtension
{
    public static Container RegisterViewModels(this Container container)
    {
        container.RegisterSingleton<MainViewModel>();
        container.Register<CreateGroupViewModel>();

        return container;
    }
}
