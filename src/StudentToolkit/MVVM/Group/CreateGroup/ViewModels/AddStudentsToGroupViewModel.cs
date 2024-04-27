using StudentToolkit.MVVM.Group.GroupInfo.ViewModels;

namespace StudentToolkit.MVVM.Group.CreateGroup.ViewModels;

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
        CancelCommand = new NavigationCommand<MainViewModel, GroupHomePageViewModel>();
    }

    public ObservableCollection<StudentViewModel> Students { get; }
    public StudentViewModel Student { get; set; }

    public ICommand GoBackCommand { get; }
    public ICommand AsyncCreateGroupCommand { get; }
    public ICommand AddStudentCommand { get; }
    public ICommand CancelCommand { get; }
}
