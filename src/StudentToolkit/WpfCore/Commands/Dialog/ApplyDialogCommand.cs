using System;

using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.Dialog;

public sealed class ApplyDialogCommand : Command
{
    private readonly DialogViewModel _viewModel;
    private readonly Func<bool>? _canExecute;

    public ApplyDialogCommand(DialogViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public ApplyDialogCommand(DialogViewModel viewModel, Func<bool> canExecute)
        : this(viewModel)
    {
        _canExecute = canExecute;
    }

    public override void Execute()
    {
        _viewModel.CreateDialogResult();
        _viewModel.Close?.Invoke();
    }

    public override bool CanExecute()
    {
        return _canExecute is null || _canExecute();
    }
}
