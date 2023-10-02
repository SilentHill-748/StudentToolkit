using System;
using System.Collections.Generic;
using System.Windows;

using StudentToolkit.MVVM.Models.DialogResults;

namespace StudentToolkit.WpfCore.Services;

/// <summary>
/// Represents a stable dependency that open dialog windows.
/// </summary>
public sealed class DialogService
{
    private readonly Dictionary<Type, Type> _viewModelToViewTypeMap = new();

    /// <summary>
    /// Register the type map between <typeparamref name="TViewModel"/> as key and <typeparamref name="TDialogView"/> as value.
    /// </summary>
    /// <typeparam name="TViewModel">The view model type.</typeparam>
    /// <typeparam name="TDialogView">The view type.</typeparam>
    public void RegisterDialog<TViewModel, TDialogView>()
        where TViewModel : DialogViewModel
        where TDialogView : Window
    {
        _viewModelToViewTypeMap[typeof(TViewModel)] = typeof(TDialogView);
    }

    /// <summary>
    /// Open dialog window that represents the specialize view model.
    /// </summary>
    /// <typeparam name="TViewModel">The view model of dialog window.</typeparam>
    /// <param name="viewModel">The instance of view model for dialog window.</param>
    /// <returns>The <see cref="DialogResult"/> object.</returns>
    public DialogResult ShowDialog<TViewModel>(TViewModel viewModel)
        where TViewModel : DialogViewModel
    {
        bool result = ShowWithResult(viewModel);

        if (result)
        {
            viewModel.Result.IsSuccess = true;
        }

        return viewModel.Result;
    }

    private bool ShowWithResult<TViewModel>(TViewModel viewModel)
        where TViewModel : DialogViewModel
    {
        var viewType = _viewModelToViewTypeMap[typeof(TViewModel)];

        var dialogVindow = (Window?)Activator.CreateInstance(viewType) ??
            throw new Exception($"Cannot create the window instance! Check {viewType.Name} and registrations!");

        dialogVindow.DataContext = viewModel;

        return dialogVindow.ShowDialog() == true;
    }
}
