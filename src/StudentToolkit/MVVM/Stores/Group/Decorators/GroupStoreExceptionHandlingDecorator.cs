using System.Threading.Tasks;

namespace StudentToolkit.MVVM.Stores.Group.Decorators;

public sealed class GroupStoreExceptionHandlingDecorator : IGroupStore, IDisposable
{
    #region Notification messages
    private const string GroupNotCreatedMessage = "Не удалось создать группу! Проверьте доступ к сети Интернет или повторите операцию позже. Если не помогает, то обратитесь к автору программы через меню 'Справка'.";
    private const string GroupNotLoadedMessage = "Не удалось загрузить данные по группе. Проверьте доступ к сети Интернет или повторите операцию позже. Если не помогает, то обратитесь к автору программы через меню 'Справка'.";
    private const string GroupNotUpdatedMessage = "Не удалось обновить данные по группе. Проверьте доступ к сети Интернет или повторите операцию позже. Если не помогает, то обратитесь к автору программы через меню 'Справка'.";
    #endregion

    private readonly IGroupStore _decoratedGroupStore;

    private bool disposedValue;

    public GroupStoreExceptionHandlingDecorator(IGroupStore decoratedGroupStore)
    {
        ArgumentNullException.ThrowIfNull(decoratedGroupStore, nameof(decoratedGroupStore));

        _decoratedGroupStore = decoratedGroupStore;
    }

    public event Action<GroupViewModel>? GroupStoreChanged
    {
        add => _decoratedGroupStore.GroupStoreChanged += value;
        remove => _decoratedGroupStore.GroupStoreChanged -= value;
    }

    public GroupViewModel Group => _decoratedGroupStore.Group;

    public async Task LoadAsync()
    {
        await TryExecuteDecoratedActionAsync(
            _decoratedGroupStore.LoadAsync,
            "Ошибка загрузки данных по группе!",
            GroupNotLoadedMessage);
    }

    public async Task CreateGroupAsync()
    {
        await TryExecuteDecoratedActionAsync(
            _decoratedGroupStore.CreateGroupAsync,
            "Ошибка создания группы!",
            GroupNotCreatedMessage);
    }

    public async Task UpdateGroupAsync()
    {
        await TryExecuteDecoratedActionAsync(
            _decoratedGroupStore.UpdateGroupAsync,
            "Ошибка обновления данных по группе!",
            GroupNotUpdatedMessage);
    }

    private async Task TryExecuteDecoratedActionAsync(Func<Task> action, string notificationTitle, string notifiactionMessage)
    {
        try
        {
            await action();
        }
        catch (Exception ex) when (ex.IsNotWrapped())
        {
            NotificationService.Alert(notificationTitle, notifiactionMessage);

            throw ex
                .WrapWithMessage("Operation of GroupStore was cancelled with an exception.")
                .SetDetail("Group.GroupCode is", Group.GroupCode);
        }
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
                if (_decoratedGroupStore is IDisposable disposableDecoratee)
                {
                    disposableDecoratee.Dispose();
                }
            }

            disposedValue = true;
        }
    }
}
