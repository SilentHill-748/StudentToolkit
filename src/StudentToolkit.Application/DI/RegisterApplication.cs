using System.Reflection;

using StudentToolkit.Application.DI.Extensions;

namespace StudentToolkit.Application.DI;

public static class RegisterApplication
{
    public static Container RegisterApplicationServices(this Container container, params Assembly[] assemblies)
    {
        container
            .RegisterServices()
            .RegisterSerilog()
            .RegisterValidation(assemblies);

        return container;
    }
}
