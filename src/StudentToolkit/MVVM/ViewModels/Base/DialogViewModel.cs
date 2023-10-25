using System;
using System.Windows;

namespace StudentToolkit.MVVM.ViewModels.Base;

public abstract class DialogViewModel : ValidatableViewModel
{
    public Action? Close { get; set; }

    public ResizeMode ResizeMode { get; set; }

    public IDialogResult? DialogResult { get; set; }

    public abstract void CreateDialogResult();
}
