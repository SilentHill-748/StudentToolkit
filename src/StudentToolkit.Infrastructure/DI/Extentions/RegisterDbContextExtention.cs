using Microsoft.Extensions.Configuration;

using StudentToolkit.Infrastructure.Data;

namespace StudentToolkit.Infrastructure.DI.Extentions;

public static class RegisterDbContextExtention
{
    public static Container RegisterDbContext(this Container container, IConfiguration configuration)
    {
        var connectionString = configuration["DefaultConnectionString"];

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        container.Register(() => new AppDbContext(options));
        container.Register<AppDbContextInitializer>();

        return container;
    }
}
