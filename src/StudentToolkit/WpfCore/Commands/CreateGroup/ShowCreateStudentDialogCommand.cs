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
        var dialogResult = DialogService.ShowDialog(
            new CreateStudentViewModel(_validator));

        if (dialogResult.IsSuccess)
            _viewModel.Students.Add((StudentViewModel)dialogResult.Result!);
    }

    public override bool CanExecute()
    {
        return _viewModel.HasNoErrors;
    }
}
