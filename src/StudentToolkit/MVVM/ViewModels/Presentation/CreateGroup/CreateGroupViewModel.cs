using StudentToolkit.MVVM.Validation.CreateGroup;

namespace StudentToolkit.MVVM.ViewModels.Presentation.CreateGroup;

public sealed class CreateGroupViewModel : ValidatableViewModel
{
    private readonly CreateGroupViewModelValidator _validator;

    private string _groupCode = string.Empty;

    public CreateGroupViewModel(
        GroupStore groupStore,
        ILogger logger,
        CreateGroupViewModelValidator validator,
        CreateStudentViewModelValidator studentValidator,
        NavigationService navigationService)
    {
        ArgumentNullException.ThrowIfNull(groupStore, nameof(groupStore));
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        ArgumentNullException.ThrowIfNull(validator, nameof(validator));
        ArgumentNullException.ThrowIfNull(studentValidator, nameof(studentValidator));
        ArgumentNullException.ThrowIfNull(navigationService, nameof(navigationService));
        
        _validator = validator;
        Group = new GroupViewModel();
        WindowTitle = "Создание группы студентов";

        Group.Students.CollectionChanged += Students_CollectionChanged;

        ShowCreateStudentDialogCommand = new ShowCreateStudentDialogCommand(this, studentValidator);
        CreateGroupCommand = new AsyncCreateGroupCommand(logger, this, groupStore, navigationService);

        Validate(_validator, this);
    }

    public GroupViewModel Group { get; }

    public string GroupCode
    {
        get => _groupCode;
        set => ValidatableSet(_validator, this, ref _groupCode, value);
    }

    public ICommand ShowCreateStudentDialogCommand { get; }
    public ICommand CreateGroupCommand { get; }

    private void Students_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Validate(_validator, this);
    }
}
