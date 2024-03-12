using StudentToolkit.WpfCore.Common.Helpers;

namespace StudentToolkit.MVVM.ViewModels.Presentation.Group.Create;

public class InputGroupDataViewModel : ViewModel
{
    public InputGroupDataViewModel(IGroupStore groupStore)
    {
        ArgumentNullException.ThrowIfNull(groupStore, nameof(groupStore));

        EducationFormats = GroupEducationHelper.CreateEducationFormats();
        EducationTypes = GroupEducationHelper.CreateEducationTypes();
        GroupData = new GroupViewModel();
        ViewTitle = "Укажите данные по Вашей группе";

        SetGroupDataAndMoveToNextViewCommand = new SetGroupDataAndMoveToNextViewCommand(this, groupStore.Group);
        CancelCommand = new NavigationCommand<MainViewModel, GroupHomePageViewModel>();
    }

    public ObservableCollection<string> EducationFormats { get; }
    public ObservableCollection<string> EducationTypes { get; }
    public GroupViewModel GroupData { get; }

    public ICommand SetGroupDataAndMoveToNextViewCommand { get; }
    public ICommand CancelCommand { get; }
}
