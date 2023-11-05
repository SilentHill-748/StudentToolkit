using System.Windows.Input;

using StudentToolkit.WpfCore.Commands.Notification;

namespace StudentToolkit.MVVM.ViewModels.Base.Notification;

public class NotificationWithConfirmViewModel : NotificationViewModel
{
    public NotificationWithConfirmViewModel(
        string title,
        string message,
        NotificationIcon icon)
            : base(title, message, icon)
    {
        OkCommand = new ConfirmNotificationCommand(this);
    }

    public bool IsConfirmed { get; set; }

    public ICommand OkCommand { get; }
}
