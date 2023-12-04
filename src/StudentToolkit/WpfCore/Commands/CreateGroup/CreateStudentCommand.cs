using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class CreateStudentCommand(CreateStudentViewModel _viewModel) 
    : Command
{
    public override void Execute()
    {
        _viewModel.DialogResult = CreateStudent();
        
        _viewModel.CloseDialog?.Invoke();
    }

    public override bool CanExecute()
    {
        return _viewModel.HasNoErrors;
    }

    private StudentViewModel CreateStudent()
    {
        return new StudentViewModel()
        {
            FirstName = _viewModel.FirstName,
            LastName = _viewModel.LastName,
            MiddleName = _viewModel.MiddleName
        };
    }
}
