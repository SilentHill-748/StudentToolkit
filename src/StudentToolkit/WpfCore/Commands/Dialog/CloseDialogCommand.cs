using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.Dialog;

public sealed class CloseDialogCommand(DialogViewModel _viewModel) 
    : Command
{
    public override void Execute()
    {
        _viewModel.CloseDialog?.Invoke();
    }
}
