namespace StudentToolkit.Domain.Dto;

public class GroupDto
{
    public Guid Id { get; set; }
    public string GroupCode { get; set; } = string.Empty;
    public ICollection<StudentDto> Students { get; set; } = new List<StudentDto>();
}
