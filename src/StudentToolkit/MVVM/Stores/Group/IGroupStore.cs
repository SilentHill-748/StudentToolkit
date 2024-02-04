using System.Threading.Tasks;

namespace StudentToolkit.MVVM.Stores.Group;

public interface IGroupStore
{
    event Action<GroupModel>? Loaded;
    event Action<GroupModel>? Updated;

    GroupModel Group { get; }

    Task LoadAsync();
    Task CreateGroupAsync();
    Task UpdateGroupAsync();
}
