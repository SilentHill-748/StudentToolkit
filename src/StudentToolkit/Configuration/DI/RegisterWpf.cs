using StudentToolkit.Configuration.DI.Extentions;

namespace StudentToolkit.Configuration.DI;

public static class RegisterWpf
{
    public static Container RegisterWpfServices(this Container container)
    {
        ViewModelSource.Provider = CreateViewModelResolver(container);

        container.Register<MainWindow>();

        container
            .RegisterServices()
            .RegisterViewModels()
            .RegisterStores();

        return container;
    }

    private static Func<Type, ViewModel> CreateViewModelResolver(Container container)
    {
        return type => (ViewModel)container.GetInstance(type);
    }
}
