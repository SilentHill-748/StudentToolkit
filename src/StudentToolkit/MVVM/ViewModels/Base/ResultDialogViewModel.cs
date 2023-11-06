namespace StudentToolkit.MVVM.ViewModels.Base;

public abstract class ResultDialogViewModel<TResult> : DialogViewModel
{
    internal TResult? DialogResult { get; set; }
}
