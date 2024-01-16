using StudentToolkit.MVVM.ViewModels.Notification;
using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.Notification;

public class ConfirmNotificationCommand : Command
{
    private readonly NotificationWithConfirmViewModel _notificationWithConfirmVm;

    public ConfirmNotificationCommand(NotificationWithConfirmViewModel notificationWithConfirmVm)
    {
        _notificationWithConfirmVm = notificationWithConfirmVm;
    }

    public override void Execute()
    {
        _notificationWithConfirmVm.IsConfirmed = true;

        _notificationWithConfirmVm.CloseDialog?.Invoke();
    }
}
