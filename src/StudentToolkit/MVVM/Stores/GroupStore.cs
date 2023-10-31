using System.Linq;
using System.Threading.Tasks;

using Mapster;

using StudentToolkit.Application.Common.Interfaces.Services;
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

    private GroupViewModel _group;

    public GroupStore(
        IGroupService groupService,
        ILogger logger)
    {
        _groupService = groupService;
        _logger = logger;
        _registryProvider = new WindowsRegistryProvider();

        _group = new GroupViewModel();
        _lazyInitialization = new Lazy<Task>(InternalLoadAsync, true);
    }

    public event Action? Loaded;
    public event Action? Updated;

    public GroupViewModel Group => _group;

    public async Task LoadAsync()
    {
        await _lazyInitialization.Value;

        _logger.Debug($"GroupStore is loaded. Group code is {_group.GroupCode}, count of students is {_group.Students.Count}.");

        Loaded?.Invoke();
    }

    public async Task CreateGroupAsync(GroupViewModel groupVm)
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

        Updated?.Invoke();
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
                
            var students = groupDto.Students.Adapt<IQueryable<StudentViewModel>>();

            _group = new GroupViewModel()
            {
                GroupCode = groupCode,
                Students = new ObservableCollection<StudentViewModel>(students)
            };
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "An exception has occured in load data to group store process.");
            throw;
        }
    }
}
