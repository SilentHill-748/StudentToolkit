using StudentToolkit.Application.Common.Interfaces;

namespace StudentToolkit.Application.Services;

public abstract class Service(IAppDbContext _appDbContext)
{
    protected IAppDbContext DbContext => _appDbContext;
}
