namespace StudentToolkit.MVVM.Notification.ViewModels;

public class NotificationViewModel : ViewModel
{
    private readonly NotificationIcon _icon;

    public NotificationViewModel(
        string title,
        string message,
        NotificationIcon icon)
    {
        WindowTitle = title;
        Message = message;

        _icon = icon;

        CloseNotificationCommand = new DelegateCommand(() => Close?.Invoke());
    }

    public Action? Close { get; set; }
    public string Message { get; }

    public Uri NotificationImageSource
        => GetImageSource();

    public ICommand CloseNotificationCommand { get; }

    private Uri GetImageSource()
    {
        var imageName = _icon.ToString().ToLower() + ".png";
        var path = Constants.WpfAssetsPath + imageName;

        return new Uri(path, UriKind.Relative);
    }
}
