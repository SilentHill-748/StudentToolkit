using StudentToolkit.MVVM.Student;
using StudentToolkit.Validation.Group;

namespace StudentToolkit.MVVM.Group;

public class GroupViewModel : ValidatableViewModel
{
    private string _groupCode = string.Empty;
    private string _educatiionDirection = string.Empty;
    private string _educatiionFormat = string.Empty;
    private string _educatiionType = string.Empty;
    private int _admissionYear;
    private bool _isInvalidStudentsCount;

    public GroupViewModel()
    {
        Validator = new GroupViewModelValidator();
        Students = [];

        Students.CollectionChanged += OnStudentsChanged;
    }

    public Guid Id { get; set; }
    public ObservableCollection<StudentViewModel> Students { get; set; }

    public bool IsInvalidStudentsCount
    {
        get => _isInvalidStudentsCount;
        set => Set(ref _isInvalidStudentsCount, value);
    }

    public string GroupCode
    {
        get => _groupCode;
        set => SetWithValidation(ref _groupCode, value.Trim());
    }
    public string EducationDirection
    {
        get => _educatiionDirection;
        set => SetWithValidation(ref _educatiionDirection, value.Trim());
    }
    public string EducationFormat
    {
        get => _educatiionFormat;
        set => SetWithValidation(ref _educatiionFormat, value.Trim());
    }
    public string EducationType
    {
        get => _educatiionType;
        set => SetWithValidation(ref _educatiionType, value.Trim());
    }
    public int AdmissionYear
    {
        get => _admissionYear;
        set => SetWithValidation(ref _admissionYear, value);
    }

    private void OnStudentsChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        IsInvalidStudentsCount = Students.Count < 6;
    }
}
