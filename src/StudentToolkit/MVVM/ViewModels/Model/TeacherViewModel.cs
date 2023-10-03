using System.ComponentModel;

namespace StudentToolkit.MVVM.ViewModels.Model;

public sealed class TeacherViewModel : ViewModel
{
    private string _firstName = string.Empty;
    private string _middlename = string.Empty;
    private string _lastName = string.Empty;

    public TeacherViewModel()
    {
        PropertyChanged += TeacherViewModel_PropertyChanged;
    }

    public string ShortFullName => $"{MiddleName} {FirstName[0]}. {LastName[0]}.";

    public string FirstName
    {
        get => _firstName;
        set => Set(ref _firstName, value);
    }
    public string MiddleName
    {
        get => _middlename;
        set => Set(ref _middlename, value);
    }
    public string LastName
    {
        get => _lastName; 
        set => Set(ref _lastName, value);
    }

    private void TeacherViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        OnPropertyChanged(nameof(ShortFullName));
    }
}
