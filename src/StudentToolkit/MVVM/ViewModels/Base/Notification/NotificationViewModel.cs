namespace StudentToolkit.MVVM.ViewModels.Base.Notification;

public class NotificationViewModel : DialogViewModel
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
    }

    public string Message { get; }

    public Uri NotificationImageSource
        => GetImageSource();

    private Uri GetImageSource()
    {
        var imageName = _icon.ToString().ToLower() + ".png";
        var path = Constants.StringConstants.WpfAssetsPath + imageName;

        return new Uri(path, UriKind.Relative);
    }
}
