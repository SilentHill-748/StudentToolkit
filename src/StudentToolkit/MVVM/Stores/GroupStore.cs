using System.Threading.Tasks;

using StudentToolkit.Domain.Dto;
using StudentToolkit.WpfCore.Providers;

namespace StudentToolkit.MVVM.Stores;

public sealed class GroupStore : IDisposable
{
    private const string GroupNotCreatedMessage = "Не удалось создать группу! Проверьте доступ к сети Интернет или повторите операцию позже. Если не помогает, то обратитесь к автору программы через меню 'Справка'.";
    private const string GroupNotLoadedMessage = "Не удалось загрузить данные по группе. Проверьте доступ к сети Интернет или повторите операцию позже. Если не помогает, то обратитесь к автору программы через меню 'Справка'.";
    private const string GroupNotUpdatedMessage = "Не удалось обновить данные по группе. Проверьте доступ к сети Интернет или повторите операцию позже. Если не помогает, то обратитесь к автору программы через меню 'Справка'.";
    private const string GroupCodeValueName = "GroupCode";

    private readonly IGroupService _groupService;
    private readonly ILogger _logger;
    private readonly WindowsRegistryProvider _registryProvider;
    private readonly Lazy<Task> _lazyInitialization;

    private readonly GroupModel _group;

    public GroupStore(
        IGroupService groupService,
        ILogger logger)
    {
        _groupService = groupService;
        _logger = logger;
        _registryProvider = new WindowsRegistryProvider();

        _group = new GroupModel();
        _lazyInitialization = new Lazy<Task>(InternalLoadAsync, true);
    }

    public event Action<GroupModel>? Loaded;
    public event Action<GroupModel>? Updated;

    public GroupModel Group => _group;

    public async Task LoadAsync()
    {
        try
        {
            await _lazyInitialization.Value;

            Loaded?.Invoke(_group);

            _logger.Information("Group was loaded successfully.");
        }
        catch (Exception ex) when (ex.IsNotWrapped())
        {
            NotificationService.Alert("Ошибка загрузки данных по группе.", GroupNotLoadedMessage);

            throw ex
                .WrapWithMessage("Load data of GroupStore was cancelled with an exception.")
                .SetDetail("Group code", _group.GroupCode);
        }
    }

    public async Task CreateGroupAsync(GroupModel groupVm)
    {
        var groupDto = groupVm.Adapt<GroupDto>();

        try
        {
            await _groupService.AddGroupAsync(groupDto);

            _registryProvider.WriteValue(GroupCodeValueName, groupVm.GroupCode);

            _logger.Information("Group was added successfully.");

            await UpdateAsync();
        }
        catch (Exception ex) when (ex.IsNotWrapped())
        {
            NotificationService.Alert("Ошибка создания группы!", GroupNotCreatedMessage);

            throw ex
                .WrapWithMessage("The creating group process was cancelled with an exception.")
                .SetDetail("Group code", groupVm.GroupCode);
        }
    }

    public async Task UpdateGroupAsync()
    {
        var groupDto = _group.Adapt<GroupDto>();

        try
        {
            await _groupService.UpdateGroupAsync(groupDto);

            await UpdateAsync();
        }
        catch (Exception ex) when (!ex.IsNotWrapped())
        {
            NotificationService.Alert("Ошибка обновления данных по группе!", GroupNotUpdatedMessage);

            throw ex
                .WrapWithMessage("The update GroupStore process was cancelled with an exception.")
                .SetDetail("Group code", _group.GroupCode);
        }
    }

    public void Dispose()
    {
        _registryProvider.Dispose();
    }

    private async Task UpdateAsync()
    {
        try
        {
            await InternalLoadAsync();

            Updated?.Invoke(_group);

            _logger.Debug("GroupStore was updated successfully.");
        }
        catch (Exception ex) when (!ex.IsNotWrapped())
        {
            NotificationService.Alert("Ошибка обновления данных по группе!", GroupNotUpdatedMessage);

            throw ex
                .WrapWithMessage("Update of GroupStore was cancelled by an exception.")
                .SetDetail("Group code", _group.GroupCode);
        }
    }

    private async Task InternalLoadAsync()
    {
        if (!_registryProvider.HasValue(GroupCodeValueName))
        {
            _logger.Debug("GroupStore isn't loaded, because group code isn't set on Windows Registry.");
            return;
        }

        var groupCode = _registryProvider.ReadValue<string>(GroupCodeValueName);

        var groupDto = await _groupService.GetGroupAsync(g => g.GroupCode.Equals(groupCode));

        _group.Update(groupDto);

        _logger.Debug("GroupStore was loaded successfully.");
    }
}
