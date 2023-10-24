using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class CloseDialogCommand : Command
{
    private readonly DialogViewModel _viewModel;

    public CloseDialogCommand(DialogViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public override void Execute()
    {
        _viewModel.Close?.Invoke();
    }
}
