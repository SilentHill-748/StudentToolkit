using StudentToolkit.MVVM.Validation.CreateGroup;
using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class ShowCreateStudentDialogCommand(
    CreateGroupViewModel viewModel,
    CreateStudentViewModelValidator validator) 
        : Command
{
    public override void Execute()
    {
        var dialogViewModel = new CreateStudentViewModel(validator);

        var student = DialogService.ShowDialog(dialogViewModel);

        if (student is null)
            return;

        viewModel.Group.Students.Add(student);
    }

    public override bool CanExecute()
    {
        return viewModel.HasNoErrors;
    }
}
