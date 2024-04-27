namespace StudentToolkit.MVVM.Group.GroupInfo.ViewModels;

public class GroupInfoViewModel : ViewModel
{
    public GroupInfoViewModel(GroupViewModel group)
    {
        ArgumentNullException.ThrowIfNull(group, nameof(group));

        Group = group;

        ViewTitle = "Данные по Вашей группе";
    }

    public GroupViewModel Group { get; }
}
