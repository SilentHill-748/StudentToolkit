using StudentToolkit.MVVM.Validation.CreateGroup;

namespace StudentToolkit.MVVM.ViewModels.Presentation.CreateGroup;

public sealed class CreateStudentViewModel : ResultDialogViewModel<StudentViewModel>
{
    private string _firstName = string.Empty;
    private string _middleName = string.Empty;
    private string _lastName = string.Empty;

    public CreateStudentViewModel(CreateStudentViewModelValidator studentValidator)
    {
        Validator = studentValidator;
        WindowTitle = "Добавить студента";

        CreateStudentCommand = new CreateStudentCommand(this);

        Validate();
    }

    public string FirstName
    {
        get => _firstName;
        set => SetWithValidation(ref _firstName, value);
    }
    public string MiddleName
    {
        get => _middleName;
        set => SetWithValidation(ref _middleName, value);
    }
    public string LastName
    {
        get => _lastName;
        set => SetWithValidation(ref _lastName, value);
    }

    public ICommand CreateStudentCommand { get; }
}
