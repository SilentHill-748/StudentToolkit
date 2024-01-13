using StudentToolkit.MVVM.Validation.CreateGroup;

namespace StudentToolkit.MVVM.ViewModels.Presentation.CreateGroup;

public sealed class CreateStudentViewModel : ResultDialogViewModel<StudentModel>
{
    private readonly CreateStudentViewModelValidator _studentValidator;

    private string _firstName = string.Empty;
    private string _middleName = string.Empty;
    private string _lastName = string.Empty;

    public CreateStudentViewModel(CreateStudentViewModelValidator studentValidator)
    {
        _studentValidator = studentValidator;
        WindowTitle = "Добавить студента";

        CreateStudentCommand = new CreateStudentCommand(this);

        Validate(_studentValidator, this);
    }

    public string FirstName
    {
        get => _firstName;
        set => ValidatableSet(_studentValidator, this, ref _firstName, value);
    }
    public string MiddleName
    {
        get => _middleName;
        set => ValidatableSet(_studentValidator, this, ref _middleName, value);
    }
    public string LastName
    {
        get => _lastName;
        set => ValidatableSet(_studentValidator, this, ref _lastName, value);
    }

    public ICommand CreateStudentCommand { get; }
}
