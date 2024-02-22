using System.Windows;

namespace StudentToolkit.WpfCore.Services;

/// <summary>
/// Represents a stable dependency that open dialog windows.
/// </summary>
public static class DialogService
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
        ResizeMode resizeMode = ResizeMode.CanResize)
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
        ResizeMode resizeMode = ResizeMode.CanResize)
    {
        InternalShowDialog(viewModel, resizeMode);
    }

    private static void InternalShowDialog(DialogViewModel viewModel, ResizeMode resizeMode)
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
