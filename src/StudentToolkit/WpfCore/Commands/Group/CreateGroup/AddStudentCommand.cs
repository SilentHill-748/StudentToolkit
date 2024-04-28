namespace StudentToolkit.WpfCore.Commands.Group.CreateGroup;

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
            AddStudent(student);
        }
    }

    private static bool IsNotValidationErrors(StudentViewModel student)
        => !student.HasErrors;

    private void AddStudent(StudentViewModel source)
    {
        var value = (StudentViewModel)source.Clone();

        _addStudentToGroupVm.Students.Add(value);

        source.ClearNameProperties(isCleanValidationErrors: true);
    }
}
