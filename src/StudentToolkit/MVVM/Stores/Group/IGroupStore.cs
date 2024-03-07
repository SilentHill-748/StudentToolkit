using System.Threading.Tasks;

namespace StudentToolkit.MVVM.Stores.Group;

public interface IGroupStore
{
    event Action<GroupViewModel>? GroupStoreChanged;

    GroupViewModel Group { get; }

    Task LoadAsync();
    Task CreateGroupAsync();
    Task UpdateGroupAsync();
}
