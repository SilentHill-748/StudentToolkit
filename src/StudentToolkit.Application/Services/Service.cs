using StudentToolkit.Application.Common.Interfaces;

namespace StudentToolkit.Application.Services;

public abstract class Service
{
    public Service(IAppDbContext appDbContext)
    {
        ArgumentNullException.ThrowIfNull(appDbContext, nameof(appDbContext));

        DbContext = appDbContext;
    }

    protected IAppDbContext DbContext { get; }
}
