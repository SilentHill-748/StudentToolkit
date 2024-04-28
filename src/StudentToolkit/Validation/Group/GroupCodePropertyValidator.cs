using System.Text.RegularExpressions;

using FluentValidation.Validators;

namespace StudentToolkit.Validation.Group;

public partial class GroupCodePropertyValidator : PropertyValidator<GroupViewModel, string>
{
    public override string Name => nameof(GroupCodePropertyValidator);

    public override bool IsValid(ValidationContext<GroupViewModel> context, string value)
    {
        bool hasOnlyDigits = HasOnlyDigits().IsMatch(value);
        bool isValidValue = GroupCodeRegex().IsMatch(value);

        return
            (!hasOnlyDigits) &&
            isValidValue;
    }

    // GroupCode should contains word chars, digits and special chars: .-_\/
    [GeneratedRegex(@"^(\w+[._\-\\\/]?)*\w+$", RegexOptions.Singleline)]
    private static partial Regex GroupCodeRegex();

    [GeneratedRegex(@"^[0-9]+$", RegexOptions.Singleline)]
    private static partial Regex HasOnlyDigits();
}
