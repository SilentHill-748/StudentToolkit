namespace StudentToolkit.MVVM.ViewModels.Model;

public sealed class GroupViewModel : ViewModel
{
    private string _groupCode = string.Empty;

    public GroupViewModel()
    {
        Students = new ObservableCollection<StudentViewModel>();
    }

    public ObservableCollection<StudentViewModel> Students { get; set; }

    public string GroupCode
    {
        get => _groupCode;
        set => Set(ref _groupCode, value);
    }
}
