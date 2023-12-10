namespace StudentToolkit.Application.Services;

public abstract class Service(IAppDbContext appDbContext)
{
    protected IAppDbContext DbContext => appDbContext;
}
