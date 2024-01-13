using StudentToolkit.MVVM.Validation.CreateGroup;
using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class ShowCreateStudentDialogCommand : Command
{
    private readonly CreateGroupViewModel _createGroupVm;
    private readonly CreateStudentViewModelValidator _createStudentVmValidator;

    public ShowCreateStudentDialogCommand(
        CreateGroupViewModel createGroupVm,
        CreateStudentViewModelValidator createStudentVmValidator)
    {
        _createGroupVm = createGroupVm;
        _createStudentVmValidator = createStudentVmValidator;
    }

    public override void Execute()
    {
        var createStudentVm = new CreateStudentViewModel(_createStudentVmValidator);

        var student = DialogService.ShowDialog(createStudentVm);

        if (student is null)
            return;

        _createGroupVm.Students.Add(student);
    }

    public override bool CanExecute()
    {
        return _createGroupVm.HasNoErrors;
    }
}
