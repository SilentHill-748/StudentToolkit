namespace StudentToolkit.MVVM.BaseViewModels;

public abstract class DialogViewModel : ValidatableViewModel
{
    protected DialogViewModel()
    {
        CloseDialogCommand = new DelegateCommand(() => Close?.Invoke());
    }

    public Action? Close { get; set; }

    public virtual ICommand CloseDialogCommand { get; }
}