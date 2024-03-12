using FluentValidation.Validators;

namespace StudentToolkit.MVVM.Validation.Group;

public class AdmissionYearPropertyValidator : PropertyValidator<GroupViewModel, int>
{
    public override string Name => nameof(AdmissionYearPropertyValidator);

    public override bool IsValid(ValidationContext<GroupViewModel> context, int value)
    {
        (int MinYear, int MaxYear) = GetValidAdmissionYearRange();

        return
            value >= MinYear &&
            value <= MaxYear;
    }

    private static (int MinYear, int MaxYear) GetValidAdmissionYearRange()
    {
        DateOnly currentDate = TimeService.CurrentDate;

        int endYear = currentDate.Year;
        int startYear = currentDate.Year - 5;
        int currentMonth = currentDate.Month;

        if (currentMonth < 9)
        {
            startYear--;
            endYear--;
        }

        return (startYear, endYear);
    }
}
