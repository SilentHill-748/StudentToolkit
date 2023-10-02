using System;

namespace StudentToolkit.Configuration.DI;

public static class RegisterServicesExtention
{
    public static Container RegisterServices(this Container container)
    {
        var assembly = typeof(RegisterServicesExtention).Assembly;

        container.RegisterSingleton<NavigationService>();
        container.RegisterSingleton(() => new DataTemplateService(assembly));
        container.RegisterSingleton(CreateDialogService);
        container.RegisterSingleton<Func<Type, object>>(() => container.GetInstance);

        return container;
    }

    private static DialogService CreateDialogService()
    {
        var dialogService = new DialogService();

        return dialogService;
    }
}
