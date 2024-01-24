using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class CreateStudentCommand : Command
{
    private readonly CreateStudentViewModel _createStudentVm;

    public CreateStudentCommand(CreateStudentViewModel createStudentVm)
    {
        _createStudentVm = createStudentVm;
    }

    public override void Execute()
    {
        _createStudentVm.DialogResult = CreateStudent();

        _createStudentVm.CloseDialogCommand.Execute(null);
    }

    public override bool CanExecute()
    {
        return !_createStudentVm.HasErrors;
    }

    private StudentModel CreateStudent()
    {
        return new StudentModel()
        {
            FirstName = _createStudentVm.FirstName,
            LastName = _createStudentVm.LastName,
            MiddleName = _createStudentVm.MiddleName
        };
    }
}
