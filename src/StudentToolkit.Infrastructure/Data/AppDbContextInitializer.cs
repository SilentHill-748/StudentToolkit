namespace StudentToolkit.Infrastructure.Data;

public sealed class AppDbContextInitializer
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger _logger;

    public AppDbContextInitializer(AppDbContext appDbContext, ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(appDbContext, nameof(appDbContext));
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));

        _dbContext = appDbContext;
        _logger = logger;
    }

    public async Task InitializeAsync()
    {
        try
        {
            await _dbContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Database migration was stopped, because was be throw exception.");
            throw;
        }
    }
}
