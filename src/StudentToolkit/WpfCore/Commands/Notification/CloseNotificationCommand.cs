using StudentToolkit.MVVM.ViewModels.Notification;
using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.Notification;

public sealed class CloseNotificationCommand : Command
{
    private readonly NotificationViewModel _notificationVm;

    public CloseNotificationCommand(NotificationViewModel notificationVm)
    {
        _notificationVm = notificationVm;
    }

    public override void Execute()
    {
        _notificationVm.CloseDialog?.Invoke();
    }
}
