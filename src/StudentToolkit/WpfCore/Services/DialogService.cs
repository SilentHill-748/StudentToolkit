using System.Windows;

namespace StudentToolkit.WpfCore.Services;

/// <summary>
/// Represents a stable dependency that open dialog windows.
/// </summary>
public sealed class DialogService
{
    /// <summary>
    /// Open <see cref="DialogWindow"/> with <see cref="DialogViewModel"/> as window content.
    /// </summary>
    /// <typeparam name="TResult">The result of <see cref="DialogWindow"/>. Represents <see cref="IDialogResult"/>.</typeparam>
    /// <param name="viewModel">The instance of view model for dialog window.</param>
    /// /// <param name="resizeMode">The resize mode of dialog window. <see cref="ResizeMode.NoResize"/> by default.</param>
    /// <returns>The <see cref="IDialogResult"/> object that represents the specified <typeparamref name="TResult"/>.</returns>
    public static TResult? ShowDialog<TResult>(DialogViewModel viewModel, ResizeMode resizeMode = ResizeMode.NoResize)
        where TResult: IDialogResult
    {
        ShowDialogInternal(viewModel, resizeMode);

        return (TResult?)viewModel.DialogResult;
    }

    private static void ShowDialogInternal(DialogViewModel viewModel, ResizeMode resizeMode)
    {
        var dialogWindow = new DialogWindow()
        {
            Content = viewModel,
            ResizeMode = resizeMode,
            Title = viewModel.WindowTitle
        };

        viewModel.Close = dialogWindow.Close;

        dialogWindow.ShowDialog();
    }
}
