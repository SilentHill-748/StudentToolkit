using StudentToolkit.MVVM.ViewModels.Presentation.CreateGroup;
using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class CancelStudentCreatingCommand : Command
{
    private readonly CreateStudentViewModel _viewModel;

    public CancelStudentCreatingCommand(CreateStudentViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public override void Execute()
    {
        _viewModel.Close?.Invoke();
    }
}
