using StudentToolkit.MVVM.Validation.CreateGroup;
using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class ShowCreateStudentDialogCommand : Command
{
    private readonly CreateGroupViewModel _viewModel;
    private readonly CreateStudentViewModelValidator _validator;

    public ShowCreateStudentDialogCommand(
        CreateGroupViewModel viewModel, 
        CreateStudentViewModelValidator validator)
    {
        _viewModel = viewModel;
        _validator = validator;
    }

    public override void Execute()
    {
        var dialogViewModel = new CreateStudentViewModel(_validator);

        var student = DialogService.ShowDialog<StudentViewModel>(dialogViewModel);

        if (student is null)
            return;

        _viewModel.Group.Students.Add(student);
    }

    public override bool CanExecute()
    {
        return _viewModel.HasNoErrors;
    }
}
