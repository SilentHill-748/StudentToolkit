using StudentToolkit.WpfCore.Commands.Dialog;

namespace StudentToolkit.MVVM.ViewModels.Base;

public abstract class DialogViewModel : ValidatableViewModel
{
    protected DialogViewModel()
    {
        CloseDialogCommand = new CloseDialogCommand(this);
    }

    public Action? CloseDialog { get; set; }

    public virtual ICommand CloseDialogCommand { get; }
}