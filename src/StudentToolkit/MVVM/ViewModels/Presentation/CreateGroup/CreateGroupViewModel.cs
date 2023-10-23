using System.Collections.ObjectModel;
using System.Windows.Input;

using StudentToolkit.MVVM.Validation.CreateGroup;

namespace StudentToolkit.MVVM.ViewModels.Presentation.CreateGroup;

public sealed class CreateGroupViewModel : ValidatableViewModel
{
    private readonly CreateGroupValidator _validator;
    private string _groupName = string.Empty;

    public CreateGroupViewModel(NavigationService navigationService)
    {
        _validator = new CreateGroupValidator();
        WindowTitle = "Создание группы студентов";

        Students = new ObservableCollection<StudentViewModel>();
        Students.CollectionChanged += Students_CollectionChanged;

        ShowCreateStudentDialogCommand = new ShowCreateStudentDialogCommand(this);
        CreateGroupCommand = new CreateGroupCommand(this, navigationService);

        Validate(_validator, this);
    }

    public ObservableCollection<StudentViewModel> Students { get; }

    public string GroupName
    {
        get => _groupName;
        set
        {
            Set(ref _groupName, value);
            Validate(_validator, this);
        }
    }

    public ICommand ShowCreateStudentDialogCommand { get; }
    public ICommand CreateGroupCommand { get; }

    private void Students_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Validate(_validator, this);
    }
}
