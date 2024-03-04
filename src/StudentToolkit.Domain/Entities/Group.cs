namespace StudentToolkit.Domain.Entities;

public sealed class Group : BaseEntity
{
    public string GroupCode { get; set; } = string.Empty;
    public string EducationDirection { get; set; } = string.Empty;
    public string EducationFormat { get; set; } = string.Empty;
    public string EducationType { get; set; } = string.Empty;
    public int AdmissionYear { get; set; }
    public ICollection<Student> Students { get; set; } = [];
}
