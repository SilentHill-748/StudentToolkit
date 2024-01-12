namespace StudentToolkit.MVVM.Models;

public class StudentModel
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;

    public string FullName => $"{LastName} {FirstName} {MiddleName}";
    public string ShortFullName => $"{LastName} {FirstName[0]}. {MiddleName[0]}.";
}
