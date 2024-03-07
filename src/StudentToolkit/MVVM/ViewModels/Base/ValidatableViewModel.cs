using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;

using FluentValidation.Results;

namespace StudentToolkit.MVVM.ViewModels.Base;

public abstract class ValidatableViewModel : ViewModel, INotifyDataErrorInfo
{
    private readonly Dictionary<string, List<string>> _errors = [];

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IValidator? Validator { get; protected set; }
    public bool HasErrors => _errors.Count > 0;

    public IEnumerable GetErrors(string? propertyName)
    {
        if (propertyName is not null)
            return _errors.GetValueOrDefault(propertyName, []);

        return new List<string>();
    }

    public void Validate()
    {
        ClearErrors();

        ValidationResult result = GetValidationResult();

        foreach (ValidationFailure failure in result.Errors)
        {
            _errors[failure.PropertyName] = [failure.ErrorMessage];

            OnErrorsChanged(failure.PropertyName);
        }
    }

    protected void SetWithValidation<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        Set(ref field, value, propertyName);
        ValidateProperty(propertyName);
    }

    protected void OnErrorsChanged([CallerMemberName] string propertyName = "")
        => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

    protected void ClearErrors(string propertyName = "")
    {
        if (string.IsNullOrEmpty(propertyName))
        {
            _errors.Clear();
            return;
        }

        _errors.Remove(propertyName);

        OnErrorsChanged(propertyName);
    }

    private void ValidateProperty(string propertyName)
    {
        ClearErrors(propertyName);

        List<ValidationFailure> failures = GetValidationResult().Errors;

        ValidationFailure? failure = failures
            .FirstOrDefault(failure => failure.PropertyName == propertyName);

        if (failure is null)
            return;

        _errors[propertyName] = [failure.ErrorMessage];

        OnErrorsChanged(propertyName);
    }

    private ValidationResult GetValidationResult()
    {
        var context = new ValidationContext<ViewModel>(this);

        return Validator is null
            ? new ValidationResult()
            : Validator.Validate(context);
    }
}
