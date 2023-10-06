using System.Windows;
using System.Windows.Controls;

using StudentToolkit.MVVM.Models.DialogResults;

namespace StudentToolkit.WpfCore.Services;

/// <summary>
/// Represents a stable dependency that open dialog windows.
/// </summary>
public sealed class DialogService
{
    private const string ContentControlName = "DialogContentView";

    /// <summary>
    /// Open dialog window that represents the specialize view model.
    /// </summary>
    /// <typeparam name="TViewModel">The view model of dialog window.</typeparam>
    /// <param name="viewModel">The instance of view model for dialog window.</param>
    /// /// <param name="resizeMode">The resize mode of dialog window.</param>
    /// <returns>The <see cref="DialogResult"/> object.</returns>
    public static DialogResult ShowDialog<TViewModel>(TViewModel viewModel, ResizeMode resizeMode = ResizeMode.NoResize)
        where TViewModel : DialogViewModel
    {
        bool result = ShowWithResult(viewModel, resizeMode);

        if (result)
        {
            viewModel.DialogResult.IsSuccess = true;
        }

        return viewModel.DialogResult;
    }

    private static bool ShowWithResult<TViewModel>(TViewModel viewModel, ResizeMode resizeMode)
        where TViewModel : DialogViewModel
    {
        var dialogWindow = new DialogWindow()
        {
            Title = viewModel.WindowTitle,
            ResizeMode = resizeMode
        };

        viewModel.Close = dialogWindow.Close;

        var control = (ContentControl)dialogWindow.FindName(ContentControlName);

        control.Content = viewModel;

        return dialogWindow.ShowDialog() == true;
    }
}
