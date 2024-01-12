using System.Threading.Tasks;

using StudentToolkit.Domain.Dto;
using StudentToolkit.WpfCore.Providers;

namespace StudentToolkit.MVVM.Stores;

public sealed class GroupStore : IDisposable
{
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
        await _lazyInitialization.Value;

        Loaded?.Invoke(_group);
    }

    public async Task CreateGroupAsync(GroupModel groupVm)
    {
        var groupDto = groupVm.Adapt<GroupDto>();

        await _groupService.AddGroupAsync(groupDto);

        _registryProvider.WriteValue(GroupCodeValueName, groupVm.GroupCode);

        await UpdateAsync();
    }

    public async Task UpdateGroupAsync()
    {
        var groupDto = _group.Adapt<GroupDto>();

        await _groupService.UpdateGroupAsync(groupDto);

        await UpdateAsync();
    }

    public void Dispose()
    {
        _registryProvider.Dispose();
    }

    private async Task UpdateAsync()
    {
        await InternalLoadAsync();

        _logger.Debug("GroupStore is updated.");

        Updated?.Invoke(_group);
    }

    private async Task InternalLoadAsync()
    {
        try
        {
            if (!_registryProvider.HasValue(GroupCodeValueName))
            {
                _logger.Debug("GroupStore isn't loaded, because group code isn't set on Windows Registry.");
                return;
            }
            
            var groupCode = _registryProvider.ReadValue<string>(GroupCodeValueName);

            var groupDto = await _groupService.GetGroupAsync(g => g.GroupCode.Equals(groupCode));

            _group.Update(groupDto);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "An exception has occured in load data to group store process.");
            throw;
        }
    }
}
