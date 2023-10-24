using System.Text.RegularExpressions;

namespace StudentToolkit.MVVM.Validation.CreateGroup;

public sealed partial class CreateStudentViewModelValidator : AbstractValidator<CreateStudentViewModel>
{
    private const string FirstNameEmptyErrorMessage
        = "Имя не должно быть пустым.";
    private const string LastNameEmptyErrorMessage
        = "Фамилия не должна быть пустым.";
    private const string MiddleNameEmptyErrorMessage
        = "Отчество не должно быть пустым.";
    private const string FirstNameIncorrectErrorMessage
        = "Имя должно состоять только из символов кириллицы, без спецсимволов.";
    private const string LastNameIncorrectErrorMessage
        = "Фамилия должна состоять только из символов кириллицы, допускаются спецсимволы пробела, апострофа и тире.";
    private const string MiddleNameIncorrectErrorMessage
        = "Отчество должно состоять только из символов кириллицы, допускаются спецсимволы пробела, апострофа и тире.";

    public CreateStudentViewModelValidator()
    {
        RuleFor(vm => vm.FirstName)
            .NotEmpty()
            .WithMessage(FirstNameEmptyErrorMessage)
            .Must(firstName => FirstNameRegex().IsMatch(firstName))
            .WithMessage(FirstNameIncorrectErrorMessage);

        RuleFor(vm => vm.LastName)
            .NotEmpty()
            .WithMessage(LastNameEmptyErrorMessage)
            .Must(lastName => LastAndMiddleNameRegex().IsMatch(lastName))
            .WithMessage(LastNameIncorrectErrorMessage);

        RuleFor(vm => vm.MiddleName)
            .NotEmpty()
            .WithMessage(MiddleNameEmptyErrorMessage)
            .Must(middleName => LastAndMiddleNameRegex().IsMatch(middleName))
            .WithMessage(MiddleNameIncorrectErrorMessage);
    }

    [GeneratedRegex("^[А-ЯЁ]{1}[а-яё]+$")]
    private static partial Regex FirstNameRegex();

    [GeneratedRegex("^[а-яёА-ЯЁ]+(?:[-' ][а-яёА-ЯЁ]+)*$")]
    private static partial Regex LastAndMiddleNameRegex();
}
