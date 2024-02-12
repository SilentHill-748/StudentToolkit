using StudentToolkit.Application.Services;

namespace StudentToolkit.Application.DI.Extensions;

public static class RegisterServicesExtension
{
    public static Container RegisterServices(this Container container)
    {
        container.RegisterSingleton<IGroupService, GroupService>();

        return container;
    }
}
