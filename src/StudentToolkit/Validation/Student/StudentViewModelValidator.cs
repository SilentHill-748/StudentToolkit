using StudentToolkit.MVVM.Validation.Student;

namespace StudentToolkit.Validation.Student;

public sealed class StudentViewModelValidator : AbstractValidator<StudentViewModel>
{
    #region Error const messages
    private const string FirstNameIsEmptyMessage = "Значение имени не может быть пустым!";
    private const string FirstNameIsBadInputMessage = "Имя студента может состоять только из символов кириллицы!";

    private const string LastNameIsEmptyMessage = "Значение фамилии не может быть пустым!";
    private const string LastNameIsBadInputMessage = "Фамилия студента может состоять только из символов кириллицы (допускаются символы пробела, апострофа и тире)!";

    private const string MiddleNameIsEmptyMessage = "Значение отчества не может быть пустым!";
    private const string MiddleNameIsBadInputMessage = "Отчество студента может состоять только из символов кириллицы (допускаются символы пробела, апострофа и тире)!";
    #endregion

    public StudentViewModelValidator()
    {
        RuleFor(vm => vm.FirstName)
            .NotEmpty()
                .WithMessage(FirstNameIsEmptyMessage)
            .SetValidator(new FirstNamePropertyValidator())
                .WithMessage(FirstNameIsBadInputMessage);

        RuleFor(vm => vm.LastName)
            .NotEmpty()
                .WithMessage(LastNameIsEmptyMessage)
            .SetValidator(new LastAndMiddleNamePropertyValidator())
                .WithMessage(LastNameIsBadInputMessage);

        RuleFor(vm => vm.MiddleName)
            .NotEmpty()
                .WithMessage(MiddleNameIsEmptyMessage)
            .SetValidator(new LastAndMiddleNamePropertyValidator())
                .WithMessage(MiddleNameIsBadInputMessage);
    }
}
