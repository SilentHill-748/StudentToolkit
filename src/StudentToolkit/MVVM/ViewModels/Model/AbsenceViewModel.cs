namespace StudentToolkit.MVVM.ViewModels.Model;

public sealed class AbsenceViewModel : ViewModel
{
    private string _reason = string.Empty;
    private uint _hours;
    private DateOnly _date;
    private StudentViewModel? _studentViewModel;
    private SubjectViewModel? _subjectViewModel;

    public string Reason
    {
        get => _reason;
        set => Set(ref _reason, value);
    }
    public uint Hours
    {
        get => _hours;
        set => Set(ref _hours, value);
    }
    public DateOnly Date
    {
        get => _date;
        set => Set(ref _date, value);
    }
    public StudentViewModel? Student
    {
        get => _studentViewModel;
        set => Set(ref _studentViewModel, value);
    }
    public SubjectViewModel? Subject
    {
        get => _subjectViewModel;
        set => Set(ref _subjectViewModel, value);
    }
}
