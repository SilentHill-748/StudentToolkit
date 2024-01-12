using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class CreateStudentCommand : Command
{
    private readonly CreateStudentViewModel _viewModel;

    public CreateStudentCommand(CreateStudentViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public override void Execute()
    {
        _viewModel.DialogResult = CreateStudent();
        
        _viewModel.CloseDialog?.Invoke();
    }

    public override bool CanExecute()
    {
        return _viewModel.HasNoErrors;
    }

    private StudentModel CreateStudent()
    {
        return new StudentModel()
        {
            FirstName = _viewModel.FirstName,
            LastName = _viewModel.LastName,
            MiddleName = _viewModel.MiddleName
        };
    }
}
