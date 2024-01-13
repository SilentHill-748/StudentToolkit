using StudentToolkit.MVVM.Validation.CreateGroup;

namespace StudentToolkit.MVVM.ViewModels.Presentation.CreateGroup;

public sealed class CreateGroupViewModel : ValidatableViewModel
{
    private readonly CreateGroupViewModelValidator _groupCodeValidator;

    private string _groupCode = string.Empty;

    public CreateGroupViewModel(
        GroupStore groupStore,
        ILogger logger,
        CreateGroupViewModelValidator groupCodeValidator,
        CreateStudentViewModelValidator studentValidator)
    {
        ArgumentNullException.ThrowIfNull(groupStore, nameof(groupStore));
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        ArgumentNullException.ThrowIfNull(groupCodeValidator, nameof(groupCodeValidator));
        ArgumentNullException.ThrowIfNull(studentValidator, nameof(studentValidator));
        
        _groupCodeValidator = groupCodeValidator;
        WindowTitle = "Создание группы студентов";

        Students = [];
        Students.CollectionChanged += Students_CollectionChanged;

        ShowCreateStudentDialogCommand = new ShowCreateStudentDialogCommand(this, studentValidator);
        CreateGroupCommand = new AsyncCreateGroupCommand(logger, this, groupStore);

        Validate(_groupCodeValidator, this);
    }

    public ObservableCollection<StudentModel> Students { get; }

    public string GroupCode
    {
        get => _groupCode;
        set => ValidatableSet(_groupCodeValidator, this, ref _groupCode, value);
    }

    public ICommand ShowCreateStudentDialogCommand { get; }
    public ICommand CreateGroupCommand { get; }

    private void Students_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        Validate(_groupCodeValidator, this);
    }
}
