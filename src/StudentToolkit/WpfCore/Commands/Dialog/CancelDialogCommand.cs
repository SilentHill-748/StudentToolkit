using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.Dialog;

public sealed class CancelDialogCommand : Command
{
    private readonly DialogViewModel _viewModel;

    public CancelDialogCommand(DialogViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public override void Execute()
    {
        _viewModel.Close?.Invoke();
    }
}
