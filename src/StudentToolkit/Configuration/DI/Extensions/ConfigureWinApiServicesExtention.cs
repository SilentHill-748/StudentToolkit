using StudentToolkit.WpfCore.Common.Interop.MessageHandlers;

namespace StudentToolkit.Configuration.DI.Extensions;

public static class ConfigureWinApiServicesExtention
{
    public static void ConfigureWinApiServices(this Container container)
    {
        IEnumerable<IMessageHandler> messageHandlers =
            container.GetAllInstances<IMessageHandler>();

        WindowInteropService.RegisterHandlers(messageHandlers);
    }
}
