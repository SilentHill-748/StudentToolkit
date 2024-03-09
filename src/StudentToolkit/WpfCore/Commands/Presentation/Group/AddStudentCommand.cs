namespace StudentToolkit.WpfCore.Commands.Presentation.Group;

public class AddStudentCommand : Command
{
    private readonly AddStudentsToGroupViewModel _addStudentToGroupVm;

    public AddStudentCommand(AddStudentsToGroupViewModel addStudentsToGroupVm)
    {
        _addStudentToGroupVm = addStudentsToGroupVm;
    }

    public override void Execute()
    {
        StudentViewModel student = _addStudentToGroupVm.Student;

        student.Validate();

        if (IsNotValidationErrors(student))
        {
            _addStudentToGroupVm.Students.Add(student);

            _addStudentToGroupVm.Student = new StudentViewModel();
        }
    }

    private static bool IsNotValidationErrors(StudentViewModel student)
        => !student.HasErrors;
        
}
