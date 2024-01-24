namespace StudentToolkit.MVVM.ViewModels.Base;

public abstract class ResultDialogViewModel<TResult> : DialogViewModel
{
    public TResult? DialogResult { get; set; }
}
