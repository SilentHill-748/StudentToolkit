using StudentToolkit.WpfCore.Common.Interop.MessageHandlers;

namespace StudentToolkit.Configuration.DI.Extensions;

public static class RegisterWinApiServicesExtension
{
    public static Container RegisterWinApiServices(this Container container)
    {
        IEnumerable<Type> messageHandlerTypes =
            container.GetTypesToRegister<IMessageHandler>(typeof(IMessageHandler).Assembly);

        container.Collection.Register<IMessageHandler>(messageHandlerTypes);

        return container;
    }
}
