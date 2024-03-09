using StudentToolkit.MVVM.ViewModels.Presentation.GroupInfo;

namespace StudentToolkit.MVVM.ViewModels.Presentation.Group;

public class AddStudentsToGroupViewModel : ViewModel
{
    public AddStudentsToGroupViewModel(IGroupStore groupStore)
    {
        Students = [];
        Student = new StudentViewModel();

        AsyncCreateGroupCommand = new AsyncCreateGroupCommand(this, groupStore);
        AddStudentCommand = new AddStudentCommand(this);
        CancelCommand = new NavigationCommand<MainViewModel, GroupNotFoundViewModel>();
    }

    public ObservableCollection<StudentViewModel> Students { get; }
    public StudentViewModel Student { get; set; }

    public ICommand AsyncCreateGroupCommand { get; }
    public ICommand AddStudentCommand { get; }
    public ICommand CancelCommand { get; }
}
