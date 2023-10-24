using Microsoft.Extensions.Configuration;

using StudentToolkit.Infrastructure.DI.Extentions;

namespace StudentToolkit.Infrastructure.DI;

public static class RegisterInfrastructure
{
    public static Container RegisterInfrastructureServices(this Container container, string[] args)
    {
        container.RegisterDbContext(args);

        return container;
    }
}
