using System;
using System.Windows;

using StudentToolkit.MVVM.Models.DialogResults;

namespace StudentToolkit.MVVM.ViewModels.Base;

public class DialogViewModel : ValidatableViewModel
{
    private DialogResult _result = new();
    private ResizeMode _resizeMode;

    public Action? Close { get; set; }

    public ResizeMode ResizeMode
    {
        get => _resizeMode;
        set => Set(ref _resizeMode, value);
    }
    public DialogResult Result
    {
        get => _result;
        set => Set(ref _result, value);
    }
}
