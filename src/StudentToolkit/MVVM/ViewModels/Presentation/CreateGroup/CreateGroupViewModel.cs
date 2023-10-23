using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StudentToolkit.MVVM.ViewModels.Presentation.CreateGroup;

public sealed class CreateGroupViewModel : ValidatableViewModel
{
    private string _groupName = string.Empty;

    public CreateGroupViewModel(NavigationService navigationService)
    {
        WindowTitle = "Создание группы студентов";

        Students = new ObservableCollection<StudentViewModel>();
        ShowCreateStudentDialogCommand = new ShowCreateStudentDialogCommand(this);
        CreateGroupCommand = new CreateGroupCommand(this, navigationService);
    }

    public ObservableCollection<StudentViewModel> Students { get; }

    public string GroupName
    {
        get => _groupName;
        set => Set(ref _groupName, value);
    }

    public ICommand ShowCreateStudentDialogCommand { get; }
    public ICommand CreateGroupCommand { get; }
}
