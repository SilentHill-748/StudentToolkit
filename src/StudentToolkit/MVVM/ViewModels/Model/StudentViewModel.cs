using StudentToolkit.MVVM.Validation.Student;

namespace StudentToolkit.MVVM.ViewModels.Model;

public class StudentViewModel : ValidatableViewModel, ICloneable
{
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _middleName = string.Empty;

    public StudentViewModel()
    {
        Validator = new StudentViewModelValidator();
    }

    public Guid Id { get; set; }
    public string FullName => GetFullName();

    public string FirstName
    {
        get => _firstName;
        set => SetWithValidation(ref _firstName, value.Trim());
    }
    public string LastName
    {
        get => _lastName;
        set => SetWithValidation(ref _lastName, value.Trim());
    }
    public string MiddleName
    {
        get => _middleName;
        set => SetWithValidation(ref _middleName, value.Trim());
    }

    public void ClearNameProperties(bool isCleanValidationErrors = false)
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        MiddleName = string.Empty;

        if (isCleanValidationErrors)
        {
            ClearErrors(nameof(FirstName));
            ClearErrors(nameof(LastName));
            ClearErrors(nameof(MiddleName));
        }
    }

    public object Clone()
    {
        return new StudentViewModel()
        {
            Id = this.Id,
            FirstName = this.FirstName,
            LastName = this.LastName,
            MiddleName = this.MiddleName
        };
    }

    public override string ToString()
    {
        return GetShortFullName();
    }

    private string GetFullName()
    {
        return HasErrors
            ? ""
            : $"{LastName} {FirstName} {MiddleName}";
    }

    private string GetShortFullName()
    {
        return HasErrors
            ? ""
            : $"{LastName} {FirstName[0]}. {MiddleName[0]}.";
    }
}
