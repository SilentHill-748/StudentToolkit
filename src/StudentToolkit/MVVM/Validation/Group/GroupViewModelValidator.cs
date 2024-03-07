namespace StudentToolkit.MVVM.Validation.Group;

public sealed class GroupViewModelValidator : AbstractValidator<GroupViewModel>
{
    #region Error const messages
    private const string GroupCodeIsEmptyMessage = "Значение шифра группы не может быть пустым!";
    private const string GroupCodeIsBadInputMessage = "В шифре группы должны быть числа, символы кириллицы или латиницы, а также спец-символы!";

    private const string EducationDirectionIsEmptyMessage = "Значение названия учебного направления не должно быть пустым!";
    private const string EducationDirectionIsBadInputMessage = "Название не должно содержать латиницу или спец-символы!";

    private const string EducationFormatIsEmptyMessage = "Не выбрано значение формата обучения!";

    private const string EducationTypeIsEmptyMessage = "Не выбрано значение типа образования!";

    private const string AdmissionYearIsBadInputMessage = "Год поступления указан неверно! Такая группа уже выпущена или еще не создана!";
    #endregion

    public GroupViewModelValidator()
    {
        RuleFor(group => group.GroupCode)
            .NotEmpty()
                .WithMessage(GroupCodeIsEmptyMessage)
            .SetValidator(new GroupCodePropertyValidator())
                .WithMessage(GroupCodeIsBadInputMessage);

        RuleFor(group => group.EducationDirection)
            .NotEmpty()
                .WithMessage(EducationDirectionIsEmptyMessage)
            .SetValidator(new EducationDirectionPropertyValidator())
                .WithMessage(EducationDirectionIsBadInputMessage);

        RuleFor(group => group.EducationFormat)
            .NotEmpty()
                .WithMessage(EducationFormatIsEmptyMessage);

        RuleFor(group => group.EducationType)
            .NotEmpty()
                .WithMessage(EducationTypeIsEmptyMessage);

        RuleFor(group => group.AdmissionYear)
            .SetValidator(new AdmissionYearPropertyValidator())
                .WithMessage(AdmissionYearIsBadInputMessage);
    }
}
