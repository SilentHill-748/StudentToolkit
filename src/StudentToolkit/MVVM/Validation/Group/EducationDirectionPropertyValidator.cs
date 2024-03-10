using System.Text.RegularExpressions;

using FluentValidation.Validators;

namespace StudentToolkit.MVVM.Validation.Group;

public partial class EducationDirectionPropertyValidator : PropertyValidator<GroupViewModel, string>
{
    public override string Name => nameof(EducationDirectionPropertyValidator);

    public override bool IsValid(ValidationContext<GroupViewModel> context, string value)
    {
        bool hasRusWordsWithSpaces = HasCyrillicCharsWithSpacesRegex().IsMatch(value);
        bool hasInvalidChars = HasInvalidCharsRegex().IsMatch(value);

        return
            (hasRusWordsWithSpaces) &&
            (!hasInvalidChars);
    }

    // String value should contains cyrillic words and space or dash char between words. Last space char is invalid.
    [GeneratedRegex(@"^([А-Яа-я]+[ -]?)+([(А-Яа-я]+[ -]?)+( - )?([А-Яа-я]+\)?)$", RegexOptions.Singleline)]
    private static partial Regex HasCyrillicCharsWithSpacesRegex();

    // String value should not contains other language words, digits and all special chars.
    [GeneratedRegex(@"^[^А-Яа-я]*$", RegexOptions.Singleline)]
    private static partial Regex HasInvalidCharsRegex();
}
