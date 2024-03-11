using StudentToolkit.MVVM.ViewModels.Presentation.GroupInfo;

namespace StudentToolkit.MVVM.ViewModels.Presentation.Group.Create;

public class AddStudentsToGroupViewModel : ViewModel
{
    public AddStudentsToGroupViewModel(IGroupStore groupStore)
    {
        Students = [];
        Student = new StudentViewModel();
        ViewTitle = "Добавьте студентов в Вашу группу";

        AsyncCreateGroupCommand = new AsyncCreateGroupCommand(this, groupStore);
        AddStudentCommand = new AddStudentCommand(this);
        GoBackCommand = new NavigationCommand<MainViewModel, InputGroupDataViewModel>();
        CancelCommand = new NavigationCommand<MainViewModel, GroupNotFoundViewModel>();
    }

    public ObservableCollection<StudentViewModel> Students { get; }
    public StudentViewModel Student { get; set; }
    public string ViewTitle { get; }

    public ICommand GoBackCommand { get; }
    public ICommand AsyncCreateGroupCommand { get; }
    public ICommand AddStudentCommand { get; }
    public ICommand CancelCommand { get; }
}
