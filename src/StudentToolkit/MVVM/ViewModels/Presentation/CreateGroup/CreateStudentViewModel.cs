using System.Windows.Input;

namespace StudentToolkit.MVVM.ViewModels.Presentation.CreateGroup;

public sealed class CreateStudentViewModel : DialogViewModel
{
    private string _firstName = string.Empty;
    private string _middleName = string.Empty;
    private string _lastName = string.Empty;

    public CreateStudentViewModel()
    {
        WindowTitle = "Добавить студента";

        CreateStudentCommand = new CreateStudentCommand(this);
        CancelCommand = new CancelStudentCreatingCommand(this);
    }

    public string FirstName
    {
        get => _firstName;
        set => Set(ref _firstName, value);
    }
    public string MiddleName
    {
        get => _middleName;
        set => Set(ref _middleName, value);
    }
    public string LastName
    {
        get => _lastName;
        set => Set(ref _lastName, value);
    }

    public ICommand CreateStudentCommand { get; }
    public ICommand CancelCommand { get; }
}
