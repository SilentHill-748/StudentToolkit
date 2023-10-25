using System.Windows.Input;

using StudentToolkit.MVVM.Validation.CreateGroup;
using StudentToolkit.WpfCore.Commands.Dialog;

namespace StudentToolkit.MVVM.ViewModels.Presentation.CreateGroup;

public sealed class CreateStudentViewModel : DialogViewModel
{
    private readonly CreateStudentViewModelValidator _validator;

    private string _firstName = string.Empty;
    private string _middleName = string.Empty;
    private string _lastName = string.Empty;

    public CreateStudentViewModel(CreateStudentViewModelValidator validator)
    {
        _validator = validator;
        WindowTitle = "Добавить студента";

        CreateStudentCommand = new ApplyDialogCommand(this, () => HasNoErrors);
        CancelCommand = new CancelDialogCommand(this);

        Validate(_validator, this);
    }

    public string FirstName
    {
        get => _firstName;
        set => ValidatableSet(_validator, this, ref _firstName, value);
    }
    public string MiddleName
    {
        get => _middleName;
        set => ValidatableSet(_validator, this, ref _middleName, value);
    }
    public string LastName
    {
        get => _lastName;
        set => ValidatableSet(_validator, this, ref _lastName, value);
    }

    public ICommand CreateStudentCommand { get; }
    public ICommand CancelCommand { get; }

    public override void CreateDialogResult()
    {
        DialogResult = new StudentViewModel()
        {
            FirstName = _firstName,
            MiddleName = _middleName,
            LastName = _lastName
        };
    }
}
