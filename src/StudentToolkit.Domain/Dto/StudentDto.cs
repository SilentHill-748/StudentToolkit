namespace StudentToolkit.Domain.Dto;

public class StudentDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string FullName {  get; set; } = string.Empty;
    public string ShortFullName {  get; set; } = string.Empty;
}
