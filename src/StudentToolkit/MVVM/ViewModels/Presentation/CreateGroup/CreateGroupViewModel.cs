using System.Collections.ObjectModel;
using System.Windows.Input;

using StudentToolkit.MVVM.Validation.CreateGroup;

namespace StudentToolkit.MVVM.ViewModels.Presentation.CreateGroup;

public sealed class CreateGroupViewModel : ValidatableViewModel
{
    private readonly CreateGroupViewModelValidator _validator;
    private string _groupCode = string.Empty;

    public CreateGroupViewModel(NavigationService navigationService)
    {
        _validator = new CreateGroupViewModelValidator();
        WindowTitle = "Создание группы студентов";

        Students = new ObservableCollection<StudentViewModel>();
        Students.CollectionChanged += Students_CollectionChanged;

        ShowCreateStudentDialogCommand = new ShowCreateStudentDialogCommand(this);
        CreateGroupCommand = new CreateGroupCommand(this, navigationService);

        Validate(_validator, this);
    }

    public ObservableCollection<StudentViewModel> Students { get; }

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
