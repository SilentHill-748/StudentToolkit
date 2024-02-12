using StudentToolkit.Infrastructure.Data;

namespace StudentToolkit.Infrastructure.DI.Extentions;

public static class RegisterDbContextExtension
{
    public static Container RegisterDbContext(this Container container, string[] args)
    {
        container.RegisterSingleton<IAppDbContext>(() => 
            new AppDbContextFactory()
                .CreateDbContext(args));

        return container;
    }
}
