using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands;

public class CloseWindowCommand : Command
{
    private readonly IClosableViewModel _closableVm;

    public CloseWindowCommand(IClosableViewModel closableVm)
    {
        _closableVm = closableVm;
    }

    public override void Execute()
    {
        _closableVm.Close?.Invoke();
    }
}
