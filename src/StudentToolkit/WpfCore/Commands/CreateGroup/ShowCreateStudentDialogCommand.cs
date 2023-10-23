using StudentToolkit.MVVM.ViewModels.Model;
using StudentToolkit.MVVM.ViewModels.Presentation.CreateGroup;
using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class ShowCreateStudentDialogCommand : Command
{
    private readonly CreateGroupViewModel _viewModel;

    public ShowCreateStudentDialogCommand(CreateGroupViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public override void Execute()
    {
        var dialogResult = DialogService.ShowDialog(
            new CreateStudentViewModel());

        if (dialogResult.IsSuccess)
            _viewModel.Students.Add((StudentViewModel)dialogResult.Result!);
    }

    public override bool CanExecute()
    {
        return _viewModel.HasNoErrors;
    }
}
