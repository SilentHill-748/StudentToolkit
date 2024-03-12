namespace StudentToolkit.Configuration.DI.Extensions;

public static class RegisterViewModelsExtension
{
    public static Container RegisterViewModels(this Container container)
    {
        container.RegisterSingleton<MainViewModel>();
        container.RegisterSingleton<AddStudentsToGroupViewModel>();
        container.RegisterSingleton<InputGroupDataViewModel>();
        container.RegisterSingleton<GroupHomePageViewModel>();
        container.Register<AboutViewModel>();

        return container;
    }
}
