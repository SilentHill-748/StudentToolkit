namespace StudentToolkit.Configuration.DI.Extentions;

public static class RegisterViewModelsExtention
{
    public static Container RegisterViewModels(this Container container)
    {
        container.Register<MainViewModel>();
        container.Register<CreateGroupViewModel>();

        return container;
    }
}
