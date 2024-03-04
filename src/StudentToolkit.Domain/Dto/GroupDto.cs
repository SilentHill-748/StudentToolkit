namespace StudentToolkit.Domain.Dto;

public class GroupDto
{
    public Guid Id { get; set; }
    public string GroupCode { get; set; } = string.Empty;
    public string EducationDirection { get; set; } = string.Empty;
    public string EducationFormat {  get; set; } = string.Empty;
    public string EducationType {  get; set; } = string.Empty;
    public int AdmissionYear { get; set; }
    public ICollection<StudentDto> Students { get; set; } = [];
}
