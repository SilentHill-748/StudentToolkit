using StudentToolkit.MVVM.Models.DialogResults;

namespace StudentToolkit.MVVM.ViewModels.Base;

public class DialogViewModel : ViewModel
{
    private DialogResult _result = new();

    public DialogResult Result
    {
        get => _result;
        set => Set(ref _result, value);
    }
}
