using StudentToolkit.MVVM.Validation.CreateGroup;

namespace StudentToolkit.MVVM.ViewModels.Presentation.CreateGroup;

public sealed class CreateGroupViewModel : ValidatableViewModel
{
    private string _groupCode = string.Empty;

    public CreateGroupViewModel(
        IGroupStore groupStore,
        CreateGroupViewModelValidator groupCodeValidator,
        CreateStudentViewModelValidator studentValidator)
    {
        ArgumentNullException.ThrowIfNull(groupStore, nameof(groupStore));
        ArgumentNullException.ThrowIfNull(groupCodeValidator, nameof(groupCodeValidator));
        ArgumentNullException.ThrowIfNull(studentValidator, nameof(studentValidator));
        
        Validator = groupCodeValidator;
        WindowTitle = "Создание группы студентов";

        Students = [];
        Students.CollectionChanged += Students_CollectionChanged;

        ShowCreateStudentDialogCommand = new ShowCreateStudentDialogCommand(this, studentValidator);
        CreateGroupCommand = new AsyncCreateGroupCommand(this, groupStore);

        Validate();
    }

    public ObservableCollection<StudentModel> Students { get; }

    public string GroupCode
    {
        get => _groupCode;
        set => SetWithValidation(ref _groupCode, value);
    }

    public ICommand ShowCreateStudentDialogCommand { get; }
    public ICommand CreateGroupCommand { get; }

    private void Students_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        Validate();
    }
}
