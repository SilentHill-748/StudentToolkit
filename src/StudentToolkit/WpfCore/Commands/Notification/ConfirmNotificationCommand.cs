using StudentToolkit.MVVM.ViewModels.Base.Notification;
using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.Notification;

public class ConfirmNotificationCommand(NotificationWithConfirmViewModel _viewModel) 
    : Command
{
    public override void Execute()
    {
        _viewModel.IsConfirmed = true;

        _viewModel.CloseDialog?.Invoke();
    }
}
