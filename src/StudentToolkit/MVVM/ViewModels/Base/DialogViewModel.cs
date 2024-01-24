using StudentToolkit.WpfCore.Commands;

namespace StudentToolkit.MVVM.ViewModels.Base;

public abstract class DialogViewModel : ValidatableViewModel, IClosableViewModel
{
    protected DialogViewModel()
    {
        CloseDialogCommand = new CloseWindowCommand(this);
    }

    public Action? Close{ get; set; }

    public virtual ICommand CloseDialogCommand { get; }
}