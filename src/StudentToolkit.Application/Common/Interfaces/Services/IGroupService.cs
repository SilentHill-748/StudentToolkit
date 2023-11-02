using System.Linq.Expressions;

namespace StudentToolkit.Application.Common.Interfaces.Services;

public interface IGroupService
{
    Task<GroupDto> GetGroupAsync(Expression<Func<Group, bool>> predicate);
    Task AddGroupAsync(GroupDto groupDto);
    Task UpdateGroupAsync(GroupDto groupDto);
}
