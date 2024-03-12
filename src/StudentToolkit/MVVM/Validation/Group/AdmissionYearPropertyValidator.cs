using FluentValidation.Validators;

namespace StudentToolkit.MVVM.Validation.Group;

public class AdmissionYearPropertyValidator : PropertyValidator<GroupViewModel, int>
{
    public override string Name => nameof(AdmissionYearPropertyValidator);

    public override bool IsValid(ValidationContext<GroupViewModel> context, int value)
    {
        (int MinYear, int MaxYear) = TimeService.GetMinMaxAdmissionYears();

        return
            value >= MinYear &&
            value <= MaxYear;
    }
}
