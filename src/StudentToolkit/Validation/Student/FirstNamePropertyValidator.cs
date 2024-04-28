using System.Text.RegularExpressions;

using FluentValidation.Validators;

namespace StudentToolkit.Validation.Student;

public partial class FirstNamePropertyValidator : PropertyValidator<StudentViewModel, string>
{
    public override string Name => nameof(FirstNamePropertyValidator);

    public override bool IsValid(ValidationContext<StudentViewModel> context, string value)
    {
        return FirstNameRegex().IsMatch(value);
    }

    // FirstName should starts with one upper and lower after cyrillic chars.
    // No digits, special chars and other not-word chars.
    [GeneratedRegex("^[А-ЯЁ]{1}[а-яё]+$", RegexOptions.Singleline)]
    private static partial Regex FirstNameRegex();
}
