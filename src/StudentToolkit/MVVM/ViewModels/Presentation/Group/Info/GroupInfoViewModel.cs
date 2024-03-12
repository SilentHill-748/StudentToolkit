namespace StudentToolkit.MVVM.ViewModels.Presentation.Group.Info;

public class GroupInfoViewModel : ViewModel
{
    public GroupInfoViewModel(GroupViewModel group)
    {
        ArgumentNullException.ThrowIfNull(group, nameof(group));

        Group = group;
        TitleView = "Данные по Вашей группе";
    }

    public GroupViewModel Group { get; }

    public string TitleView { get; } 
}
