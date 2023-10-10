using Microsoft.Extensions.Configuration;

using StudentToolkit.Infrastructure.DI.Extentions;

namespace StudentToolkit.Infrastructure.DI;

public static class RegisterInfrastructure
{
    public static Container RegisterInfrastructureServices(this Container container, IConfiguration configuration)
    {
        container.RegisterDbContext(configuration);

        return container;
    }
}
