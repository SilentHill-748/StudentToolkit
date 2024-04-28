using System.Threading.Tasks;

namespace StudentToolkit.Stores.Group;

public interface IGroupStore
{
    event Action<GroupViewModel>? GroupStoreChanged;

    GroupViewModel Group { get; }

    Task LoadAsync();
    Task CreateGroupAsync();
    Task UpdateGroupAsync();
}
