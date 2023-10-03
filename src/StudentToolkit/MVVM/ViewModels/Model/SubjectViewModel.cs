namespace StudentToolkit.MVVM.ViewModels.Model;

public sealed class SubjectViewModel : ViewModel
{
    private string _name = string.Empty;
    private TeacherViewModel? _teacherViewModel;

    public string Name
    {
        get => _name;
        set => Set(ref _name, value);
    }
    public TeacherViewModel? Teacher
    {
        get => _teacherViewModel;
        set => Set(ref _teacherViewModel, value);
    }
}
