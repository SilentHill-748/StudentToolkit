using StudentToolkit.MVVM.ViewModels.Base.Notification;
using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.Notification;

public class ConfirmNotificationCommand : Command
{
    private readonly NotificationWithConfirmViewModel _viewModel;

    public ConfirmNotificationCommand(NotificationWithConfirmViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public override void Execute()
    {
        _viewModel.IsConfirmed = true;

        _viewModel.CloseDialog?.Invoke();
    }
}
