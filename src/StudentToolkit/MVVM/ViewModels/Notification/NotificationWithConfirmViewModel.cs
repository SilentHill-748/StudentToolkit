using StudentToolkit.WpfCore.Commands.Notification;

namespace StudentToolkit.MVVM.ViewModels.Notification;

public class NotificationWithConfirmViewModel : NotificationViewModel
{
    public NotificationWithConfirmViewModel(string title, string message)
        : base(title, message, NotificationIcon.Ask)
    {
        ApplyNotificationCommand = new ConfirmNotificationCommand(this);
    }

    public bool IsConfirmed { get; set; }

    public ICommand ApplyNotificationCommand { get; }
}
