using System.Text.RegularExpressions;

namespace StudentToolkit.MVVM.Validation.CreateGroup;

public sealed partial class CreateGroupViewModelValidator : AbstractValidator<CreateGroupViewModel>
{
    private const string GroupCodeEmptyErrorMessage
        = "Шифр группы должен быть заполнен.";
    private const string GroupCodeIncorrectErrorMessage 
        = "Шифр группы указан неверно. Пример: ЭВТ-99-9бЛФ";

    public CreateGroupViewModelValidator()
    {
        RuleFor(vm => vm.GroupCode)
            .NotEmpty()
            .WithMessage(GroupCodeEmptyErrorMessage)
            .Must(name => NameRegex().IsMatch(name))
            .WithMessage(GroupCodeIncorrectErrorMessage);
    }

    [GeneratedRegex("^([А-Я]{2,3})-(\\d{2})-(\\d{1}[бм]{1}ЛФ)")]
    private static partial Regex NameRegex();
}
