using System.Windows;

using StudentToolkit.MVVM.ViewModels.Base.Notification;

namespace StudentToolkit.WpfCore.Services;

/// <summary>
/// Represents a stable dependency that open dialog windows.
/// </summary>
public sealed class DialogService
{
    /// <summary>
    /// Open the dialog window.
    /// </summary>
    /// <typeparam name="TResult">The result of <see cref="DialogWindow"/>. Represents <see cref="IDialogResult"/>.</typeparam>
    /// <param name="viewModel">The instance of view model for dialog window.</param>
    /// /// <param name="resizeMode">The resize mode of dialog window. <see cref="ResizeMode.NoResize"/> by default.</param>
    /// <returns>The result object that represents the specified <typeparamref name="TResult"/>.</returns>
    public static TResult? ShowDialog<TResult>(
        ResultDialogViewModel<TResult> viewModel,
        ResizeMode resizeMode = ResizeMode.NoResize)
    {
        InternalShowDialog(viewModel, resizeMode);

        return viewModel.DialogResult;
    }

    /// <summary>
    /// <inheritdoc cref="ShowDialog{TResult}(ResultDialogViewModel{TResult}, ResizeMode)"/>
    /// </summary>
    /// <param name="viewModel">The instance of view model for dialog window.</param>
    /// <param name="resizeMode">The resize mode of dialog window. <see cref="ResizeMode.NoResize"/> by default.</param>
    public static void ShowDialog(
        DialogViewModel viewModel, 
        ResizeMode resizeMode = ResizeMode.NoResize)
    {
        InternalShowDialog(viewModel, resizeMode);
    }

    /// <summary>
    /// Show notification window.
    /// </summary>
    /// <param name="title">The notification window title.</param>
    /// <param name="message">The notification message.</param>
    /// <param name="icon">The notification message icon.</param>
    public static void ShowNotification(string title, string message, NotificationIcon icon)
    {
        var notificationVm = new NotificationViewModel(title, message, icon);

        InternalShowDialog(notificationVm, ResizeMode.NoResize);
    }

    /// <summary>
    /// <inheritdoc cref="ShowNotification(string, string, NotificationIcon)"/>
    /// </summary>
    /// <param name="title">The notification window title.</param>
    /// <param name="message">The notification message.</param>
    /// <param name="icon">The notification message icon.</param>
    /// <returns><see langword="True"/> if the notification is confirm; overwide <see langword="False"/>.</returns>
    public static bool ShowNotificationWithConfirm(string title, string message, NotificationIcon icon)
    {
        var notificationVm = new NotificationWithConfirmViewModel(title, message, icon);

        InternalShowDialog(notificationVm, ResizeMode.NoResize);

        return notificationVm.IsConfirmed;
    }

    private static void InternalShowDialog(DialogViewModel viewModel, ResizeMode resizeMode)
    {
        var dialogWindow = new DialogWindow()
        {
            Content = viewModel,
            ResizeMode = resizeMode,
            Title = viewModel.WindowTitle
        };

        viewModel.CloseDialog = dialogWindow.Close;

        dialogWindow.ShowDialog();
    }
}
