namespace StudentToolkit.Domain.Entities;

public sealed class Subject : BaseEntity
{
    public string? Name { get; set; }
    public Teacher? Teacher { get; set; }
}
