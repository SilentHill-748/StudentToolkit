using StudentToolkit.MVVM.ViewModels.Base.Notification;

namespace StudentToolkit.WpfCore.Services;

public static class NotificationService
{
    /// <summary>
    /// Open the window with specified title and alert message.
    /// </summary>
    /// <param name="title">The title of notification window.</param>
    /// <param name="message">The message.</param>
    public static void Alert(string title, string message)
    {
        InternalShow(title, message, NotificationIcon.Error);
    }

    /// <summary>
    /// Open the window with specified title and warning message.
    /// </summary>
    /// <param name="title">The title of notification window.</param>
    /// <param name="message">The message.</param>
    public static void Warning(string title, string message)
    {
        InternalShow(title, message, NotificationIcon.Warning);
    }

    /// <summary>
    /// Open the window with specified title and information message.
    /// </summary>
    /// <param name="title">The title of notification window.</param>
    /// <param name="message">The message.</param>
    public static void Information(string title, string message)
    {
        InternalShow(title, message, NotificationIcon.Info);
    }

    /// <summary>
    /// Open the window with specified title and message and wait for confirmation.
    /// </summary>
    /// <param name="title">The title of notification window.</param>
    /// <param name="message">The message.</param>
    /// <returns><see langword="True"/> if the notification is confirm; overwide <see langword="False"/>.</returns>
    public static bool Ask(string title, string message)
    {
        var notificationVm = new NotificationWithConfirmViewModel(title, message);

        ShowDialog(title, notificationVm);

        return notificationVm.IsConfirmed;
    }

    private static void InternalShow(string title, string message, NotificationIcon icon)
    {
        var notificationVm = new NotificationViewModel(title, message, icon);

        ShowDialog(title, notificationVm);
    }

    private static void ShowDialog(string title, DialogViewModel viewModel)
    {
        var window = new DialogWindow()
        {
            ResizeMode = System.Windows.ResizeMode.NoResize,
            Content = viewModel,
            Title = title
        };

        viewModel.CloseDialog = window.Close;

        window.ShowDialog();
    }
}
