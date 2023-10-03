namespace StudentToolkit.MVVM.ViewModels.Model;

public sealed class GroupViewModel : ViewModel
{
    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => Set(ref _name, value);
    }
}
