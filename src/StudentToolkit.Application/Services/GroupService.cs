using System.Linq.Expressions;

using StudentToolkit.Domain.Exceptions;

namespace StudentToolkit.Application.Services;

public sealed class GroupService(IAppDbContext appDbContext)
    : Service(appDbContext), IGroupService
{
    public async Task<GroupDto> GetGroupAsync(Expression<Func<Group, bool>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate, nameof(predicate));

        var group = await DbContext.Groups
            .Include(g => g.Students)
            .FirstOrDefaultAsync(predicate) ??
                throw new GroupNotFoundException(predicate);

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
            .FirstOrDefaultAsync(g => g.GroupCode == groupDto.GroupCode) ??
                throw new GroupNotFoundException(groupDto);

        group.GroupCode = groupDto.GroupCode;
        group.Students = groupDto.Students.Adapt<ICollection<Student>>();

        DbContext.Groups.Update(group);
        await DbContext.SaveChangesAsync();
    }
}
