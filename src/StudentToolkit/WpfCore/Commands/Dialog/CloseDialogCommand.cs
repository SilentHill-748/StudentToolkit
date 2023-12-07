using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.Dialog;

public sealed class CloseDialogCommand(DialogViewModel viewModel) 
    : Command
{
    public override void Execute()
    {
        viewModel.CloseDialog?.Invoke();
    }
}
