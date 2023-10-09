namespace StudentToolkit.Infrastructure.Data;

public sealed class AppDbContextInitializer
{
    private readonly AppDbContext _dbContext;

    public AppDbContextInitializer(AppDbContext appDbContext)
    {
        _dbContext = appDbContext;
    }

    public async Task InitializeAsync()
    {
        await _dbContext.Database.MigrateAsync();
    }
}
