namespace StudentToolkit.MVVM.ViewModels.Notification;

public class NotificationWithConfirmViewModel : NotificationViewModel
{
    public NotificationWithConfirmViewModel(string title, string message)
        : base(title, message, NotificationIcon.Ask)
    {
        ConfirmNotificationCommand = new DelegateCommand(CloseWithConfirm);
    }

    public bool IsConfirmed { get; set; }

    public ICommand ConfirmNotificationCommand { get; }

    private void CloseWithConfirm()
    {
        IsConfirmed = true;

        Close?.Invoke();
    }
}
