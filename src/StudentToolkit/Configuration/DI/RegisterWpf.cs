using StudentToolkit.Configuration.DI.Extentions;

namespace StudentToolkit.Configuration.DI;

public static class RegisterWpf
{
    public static Container RegisterWpfServices(this Container container)
    {
        ConfigureViewModelSource(container);

        container.Register(() => CreateMainWindow(container));

        container
            .RegisterServices()
            .RegisterViewModels()
            .RegisterStores();

        return container;
    }

    private static MainWindow CreateMainWindow(Container container)
    {
        NavigationViewModel navigationVm = new()
        {
            CurrentViewModel = container.GetInstance<MainViewModel>()
        };

        return new MainWindow(navigationVm);
    }

    private static void ConfigureViewModelSource(Container container)
    {
        Func<Type, ViewModel> viewModelProvider = CreateViewModelProvider(container);

        ViewModelSource.SetViewModelProvider(viewModelProvider);
    }

    private static Func<Type, ViewModel> CreateViewModelProvider(Container container)
    {
        return type => (ViewModel)container.GetInstance(type);
    }
}
