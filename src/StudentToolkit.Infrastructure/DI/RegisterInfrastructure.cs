using StudentToolkit.Infrastructure.DI.Extensions;

namespace StudentToolkit.Infrastructure.DI;

public static class RegisterInfrastructure
{
    public static Container RegisterInfrastructureServices(this Container container, string[] args)
    {
        container.RegisterDbContext(args);

        return container;
    }
}
