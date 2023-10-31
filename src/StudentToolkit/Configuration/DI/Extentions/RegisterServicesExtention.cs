using System;

namespace StudentToolkit.Configuration.DI.Extentions;

public static class RegisterServicesExtention
{
    public static Container RegisterServices(this Container container)
    {
        var assembly = typeof(RegisterServicesExtention).Assembly;

        container.RegisterSingleton<NavigationService>();
        container.RegisterSingleton(() => new DataTemplateService(assembly));
        container.RegisterSingleton<Func<Type, object>>(() => container.GetInstance);

        return container;
    }
}
