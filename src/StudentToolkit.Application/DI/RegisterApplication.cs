using System.Reflection;

using StudentToolkit.Application.DI.Extentions;

namespace StudentToolkit.Application.DI;

public static class RegisterApplication
{
    public static Container RegisterApplicationServices(this Container container, params Assembly[] assemblies)
    {
        container
            .RegisterSerilog()
            .RegisterValidation(assemblies);

        return container;
    }
}
