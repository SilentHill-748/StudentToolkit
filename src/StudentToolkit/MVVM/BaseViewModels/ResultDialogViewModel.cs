namespace StudentToolkit.MVVM.BaseViewModels;

public abstract class ResultDialogViewModel<TResult> : DialogViewModel
{
    public TResult? DialogResult { get; set; }
}
