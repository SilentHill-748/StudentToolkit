namespace StudentToolkit.Domain.Entities;

public sealed class Teacher : PersonEntity
{
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
