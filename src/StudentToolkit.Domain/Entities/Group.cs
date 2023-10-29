namespace StudentToolkit.Domain.Entities;

public sealed class Group : BaseEntity
{
    public string GroupCode { get; set; } = string.Empty;
    public ICollection<Student> Students { get; set; } = new List<Student>();
}
