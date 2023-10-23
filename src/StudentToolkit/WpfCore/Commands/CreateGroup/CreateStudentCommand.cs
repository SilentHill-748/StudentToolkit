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
        _viewModel.DialogResult = new DialogResult()
        {
            IsSuccess = true,
            Result = CreateStudent()
        };

        _viewModel.Close?.Invoke();
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
            MiddleName = _viewModel.MiddleName,
            LastName = _viewModel.LastName
        };
    }
}
