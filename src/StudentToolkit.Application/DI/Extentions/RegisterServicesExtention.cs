using StudentToolkit.Application.Services;

namespace StudentToolkit.Application.DI.Extentions;

public static class RegisterServicesExtention
{
    public static Container RegisterServices(this Container container)
    {
        container.RegisterSingleton<IGroupService, GroupService>();

        return container;
    }
}
