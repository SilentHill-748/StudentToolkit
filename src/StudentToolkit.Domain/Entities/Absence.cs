namespace StudentToolkit.Domain.Entities;

public sealed class Absence : BaseEntity
{
    public string Reason { get; set; } = string.Empty;
    public uint Hours { get; set; }
    public DateOnly Date {  get; set; }
    
    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = new Subject();

    public Guid StudentId { get; set; }
    public Student Student { get; set; } = new Student();
}
