using System.Threading.Tasks;

using StudentToolkit.Domain.Dto;
using StudentToolkit.WpfCore.Providers;

namespace StudentToolkit.MVVM.Stores.Group;

public sealed class GroupStore : IGroupStore, IDisposable
{
    private const string GroupCodeValueName = "GroupCode";

    private readonly IGroupService _groupService;
    private readonly WindowsRegistryProvider _registryProvider;
    private readonly Lazy<Task> _lazyInitialization;

    private bool disposedValue;

    public GroupStore(IGroupService groupService)
    {
        ArgumentNullException.ThrowIfNull(groupService, nameof(groupService));

        _groupService = groupService;
        _registryProvider = new WindowsRegistryProvider();

        Group = new GroupModel();
        _lazyInitialization = new Lazy<Task>(InternalLoadAsync, true);
    }

    public event Action<GroupModel>? Loaded;
    public event Action<GroupModel>? Updated;

    public GroupModel Group { get; }

    public async Task LoadAsync()
    {
        await _lazyInitialization.Value;

        Loaded?.Invoke(Group);
    }

    public async Task CreateGroupAsync()
    {
        var groupDto = Group.Adapt<GroupDto>();

        await _groupService.AddGroupAsync(groupDto);

        _registryProvider.WriteValue(GroupCodeValueName, Group.GroupCode);

        await ReloadAsync();
    }

    public async Task UpdateGroupAsync()
    {
        var groupDto = Group.Adapt<GroupDto>();

        await _groupService.UpdateGroupAsync(groupDto);

        await ReloadAsync();
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
                _registryProvider.Dispose();
            }

            disposedValue = true;
        }
    }

    private async Task ReloadAsync()
    {
        await _lazyInitialization.Value;

        Updated?.Invoke(Group);
    }

    private async Task InternalLoadAsync()
    {
        if (_registryProvider.HasValue(GroupCodeValueName))
        {
            var groupCode = _registryProvider.ReadValue<string>(GroupCodeValueName);

            var groupDto = await _groupService.GetGroupAsync(g => g.GroupCode.Equals(groupCode));

            Group.Update(groupDto);
        }
    }
}
