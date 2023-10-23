using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using FluentValidation.Results;

namespace StudentToolkit.MVVM.ViewModels.Base;

public class ValidatableViewModel : ViewModel, INotifyDataErrorInfo
{
    private readonly Dictionary<string, List<string>> _errors;

    public ValidatableViewModel()
    {
        _errors = new Dictionary<string, List<string>>();
    }

    public bool HasErrors => _errors.Count > 0;
    public bool HasNoErrors => _errors.Count == 0;

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IEnumerable GetErrors(string? propertyName)
    {
        if (propertyName is not null)
            return _errors.GetValueOrDefault(propertyName, new List<string>());

        return new List<string>();
    }

    protected void Validate<TViewModel>(
        AbstractValidator<TViewModel> validator,
        TViewModel instance,
        [CallerMemberName] string propertyName = "")
    {
        ArgumentNullException.ThrowIfNull(validator, nameof(validator));
        ArgumentNullException.ThrowIfNull(instance, nameof(instance));

        ValidationResult result = validator.Validate(instance);

        ClearErrors(propertyName);

        AddErrors(result);
    }

    protected void OnErorrsChanged([CallerMemberName] string propertyName = "")
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    private void ClearErrors(string propertyName = "")
    {
        if (string.IsNullOrEmpty(propertyName))
        {
            _errors.Clear();
            return;
        }

        _errors.Remove(propertyName);

        OnErorrsChanged(propertyName);
    }


    private void AddErrors(ValidationResult validationResult)
    {
        var errors = validationResult.Errors;

        foreach (ValidationFailure error in errors)
        {
            AddError(error);
        }
    }

    private void AddError(ValidationFailure error)
    {
        if (!_errors.ContainsKey(error.PropertyName))
            _errors[error.PropertyName] = new List<string>();

        _errors[error.PropertyName].Add(error.ErrorMessage);

        OnErorrsChanged(error.PropertyName);
    }
}
