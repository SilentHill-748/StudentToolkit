using StudentToolkit.Domain.Dto;

namespace StudentToolkit.MVVM.Models;

public class GroupModel
{
    public Guid Id { get; set; }

    public string GroupCode { get; set; } = string.Empty;

    public IEnumerable<StudentModel> Students { get; set; } = [];

    public void Update(GroupDto groupDto)
    {
        Students = groupDto.Students.Adapt<IEnumerable<StudentModel>>();

        Id = groupDto.Id;
        GroupCode = groupDto.GroupCode;
    }
}
