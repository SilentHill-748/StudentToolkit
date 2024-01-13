using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.Dialog;

public sealed class CloseDialogCommand : Command
{
    private readonly DialogViewModel _dialogVm;

    public CloseDialogCommand(DialogViewModel dialogVm)
    {
        _dialogVm = dialogVm;
    }

    public override void Execute()
    {
        _dialogVm.CloseDialog?.Invoke();
    }
}
