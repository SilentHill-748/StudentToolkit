using StudentToolkit.WpfCore.Commands.Base;

namespace StudentToolkit.WpfCore.Commands.CreateGroup;

public sealed class CreateStudentCommand(CreateStudentViewModel viewModel) 
    : Command
{
    public override void Execute()
    {
        viewModel.DialogResult = CreateStudent();
        
        viewModel.CloseDialog?.Invoke();
    }

    public override bool CanExecute()
    {
        return viewModel.HasNoErrors;
    }

    private StudentViewModel CreateStudent()
    {
        return new StudentViewModel()
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            MiddleName = viewModel.MiddleName
        };
    }
}
