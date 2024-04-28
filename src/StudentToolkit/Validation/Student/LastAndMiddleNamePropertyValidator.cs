using System.Text.RegularExpressions;

using FluentValidation.Validators;

namespace StudentToolkit.Validation.Student;

public partial class LastAndMiddleNamePropertyValidator : PropertyValidator<StudentViewModel, string>
{
    public override string Name => nameof(LastAndMiddleNamePropertyValidator);

    public override bool IsValid(ValidationContext<StudentViewModel> context, string value)
    {
        return LastAndMiddleNameRegex().IsMatch(value);
    }

    // LastName and MiddleName can contains special char: [-, ] between words.
    // Also them should starts with one upper char and lower chars after.
    [GeneratedRegex("^[А-ЯЁ]{1}[а-яёА-ЯЁ]+(?:[-' ][а-яёА-ЯЁ]+)*$", RegexOptions.Singleline)]
    private static partial Regex LastAndMiddleNameRegex();
}
