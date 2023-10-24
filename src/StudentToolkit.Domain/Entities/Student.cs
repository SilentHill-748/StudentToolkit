namespace StudentToolkit.Domain.Entities;

public sealed class Student : PersonEntity
{
    public Guid GroupId { get; set; }
    public Group? Group { get; set; }
    public ICollection<Absence>? Absences { get; set; }
}
