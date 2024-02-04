using StudentToolkit.Configuration.DI.Extentions;

namespace StudentToolkit.Configuration.DI;

public static class RegisterWpf
{
    public static Container RegisterWpfServices(this Container container)
    {
        ConfigureViewModelSource(container);

        container.Register<MainWindow>();

        container
            .RegisterServices()
            .RegisterViewModels()
            .RegisterStores();

        return container;
    }

    private static void ConfigureViewModelSource(Container container)
    {
        Func<Type, ViewModel> viewModelProvider = CreateViewModelResolver(container);

        ViewModelSource.SetViewModelProvider(viewModelProvider);
    }

    private static Func<Type, ViewModel> CreateViewModelResolver(Container container)
    {
        return type => (ViewModel)container.GetInstance(type);
    }
}
