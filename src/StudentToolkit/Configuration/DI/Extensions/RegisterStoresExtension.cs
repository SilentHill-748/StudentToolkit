using SimpleInjector;

using StudentToolkit.Stores.Group.Decorators;

namespace StudentToolkit.Configuration.DI.Extensions;

public static class RegisterStoresExtension
{
    public static Container RegisterStores(this Container container)
    {
        container.RegisterSingleton<IGroupStore, GroupStore>();
        container.RegisterDecorator<IGroupStore, GroupStoreLoggerDecorator>(Lifestyle.Singleton);
        container.RegisterDecorator<IGroupStore, GroupStoreExceptionHandlingDecorator>(Lifestyle.Singleton);

        return container;
    }
}
