using System.Linq.Expressions;

using StudentToolkit.Domain.Dto;

namespace StudentToolkit.Domain.Exceptions;

public sealed class GroupNotFoundException : Exception
{
    public GroupNotFoundException(GroupDto groupDto)
    {
        Message = $"Group '{groupDto.GroupCode}' with id '{groupDto.Id}' is not found.";
    }

    public GroupNotFoundException(Expression predicate)
    {
        Message = $"Group is not found by predicate:\n{predicate}";
    }

    public override string Message { get; }
}
