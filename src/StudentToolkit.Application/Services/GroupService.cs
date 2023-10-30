using System.Linq.Expressions;

using StudentToolkit.Application.Common.Interfaces;

namespace StudentToolkit.Application.Services;

public sealed class GroupService : Service, IGroupService
{
    public GroupService(IAppDbContext appDbContext) 
        : base(appDbContext)
    { }

    public async Task<GroupDto> GetGroupAsync(Expression<Func<Group, bool>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate, nameof(predicate));

        var group = await DbContext.Groups
            .FirstOrDefaultAsync(predicate) ??
                throw new ArgumentException($"Group is not found by predicate.\n{predicate}");

        return group.Adapt<GroupDto>();
    }

    public async Task AddGroupAsync(GroupDto groupDto)
    {
        ArgumentNullException.ThrowIfNull(groupDto, nameof(groupDto));

        var group = groupDto.Adapt<Group>();

        await DbContext.Groups.AddAsync(group);
        await DbContext.SaveChangesAsync();
    }

    public async Task UpdateGroupAsync(GroupDto groupDto)
    {
        ArgumentNullException.ThrowIfNull(groupDto, nameof(groupDto));

        var group = await DbContext.Groups
            .FirstOrDefaultAsync(g => g.Id == groupDto.Id) ??
                throw new ArgumentException($"Group '{groupDto.Id}' is not found.");

        group.GroupCode = groupDto.GroupCode;
        group.Students = groupDto.Students.Adapt<ICollection<Student>>();

        DbContext.Groups.Update(group);
        await DbContext.SaveChangesAsync();
    }
}
