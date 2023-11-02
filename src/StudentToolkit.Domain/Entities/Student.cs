namespace StudentToolkit.Domain.Entities;

public sealed class Student : PersonEntity
{
    public Guid GroupId { get; set; }
    public Group Group { get; set; } = new Group();
    public ICollection<Absence> Absences { get; set; } = new List<Absence>();
}
