namespace StudentToolkit.Domain.Entities;

public sealed class Group : BaseEntity
{
    public string? GroupCode { get; set; }
    public ICollection<Student>? Students { get; set; }
}
