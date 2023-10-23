namespace StudentToolkit.Configuration.DI;

public static class RegisterViewModelsExtention
{
    public static Container RegisterViewModels(this Container container)
    {
        container.Register<MainViewModel>();
        container.Register<NavigationViewModel>();
        container.Register<CreateGroupViewModel>();

        return container;
    }
}
