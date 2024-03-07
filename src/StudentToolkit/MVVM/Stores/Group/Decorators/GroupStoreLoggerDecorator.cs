using System.Threading.Tasks;

namespace StudentToolkit.MVVM.Stores.Group.Decorators;

public sealed class GroupStoreLoggerDecorator : IGroupStore, IDisposable
{
    private readonly IGroupStore _decorateeGroupStore;
    private readonly ILogger _logger;

    private bool disposedValue;

    public GroupStoreLoggerDecorator(
        IGroupStore decorateeGroupStore,
        ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(decorateeGroupStore, nameof(decorateeGroupStore));
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));

        _decorateeGroupStore = decorateeGroupStore;
        _logger = logger;
    }

    public event Action<GroupViewModel>? GroupStoreChanged
    {
        add => _decorateeGroupStore.GroupStoreChanged += value;
        remove => _decorateeGroupStore.GroupStoreChanged -= value;
    }

    public GroupViewModel Group => _decorateeGroupStore.Group;

    public async Task LoadAsync()
    {
        await _decorateeGroupStore.LoadAsync();

        if (string.IsNullOrWhiteSpace(Group.GroupCode))
        {
            _logger.Information("Loading of group data was successfully, but data isn't loaded.");
        }
        else
        {
            _logger.Information("Loading/reloading of group data was successfully.");
        }
    }

    public async Task CreateGroupAsync()
    {
        await _decorateeGroupStore.CreateGroupAsync();

        _logger.Debug("Group was added to DB.");
        _logger.Information("Group was created successfully.");
    }

    public async Task UpdateGroupAsync()
    {
        await _decorateeGroupStore.UpdateGroupAsync();

        _logger.Information("Group was updated successfully.");
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                if (_decorateeGroupStore is IDisposable disposableDecoratee)
                {
                    disposableDecoratee.Dispose();
                }
            }

            disposedValue = true;
        }
    }
}
