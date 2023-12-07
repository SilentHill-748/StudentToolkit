using StudentToolkit.MVVM.ViewModels.Base.Notification;
using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.Notification;

public class ConfirmNotificationCommand(NotificationWithConfirmViewModel viewModel) 
    : Command
{
    public override void Execute()
    {
        viewModel.IsConfirmed = true;

        viewModel.CloseDialog?.Invoke();
    }
}
