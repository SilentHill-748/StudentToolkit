using System.ComponentModel.DataAnnotations.Schema;

namespace StudentToolkit.Domain.Common;

public abstract class PersonEntity : BaseEntity
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    [NotMapped]
    public string FullName => $"{MiddleName} {FirstName} {LastName}";
    [NotMapped]
    public string ShortFullName => $"{MiddleName} {FirstName![0]} {LastName![0]}";
}
