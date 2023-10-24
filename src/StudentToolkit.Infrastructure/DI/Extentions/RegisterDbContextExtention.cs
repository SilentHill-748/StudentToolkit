using StudentToolkit.Infrastructure.Data;

namespace StudentToolkit.Infrastructure.DI.Extentions;

public static class RegisterDbContextExtention
{
    public static Container RegisterDbContext(this Container container, string[] args)
    {
        container.RegisterSingleton(() => new AppDbContextFactory().CreateDbContext(args));

        return container;
    }
}
