namespace StudentToolkit.Domain.Entities;

public sealed class Subject : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; } = new Teacher();
}
