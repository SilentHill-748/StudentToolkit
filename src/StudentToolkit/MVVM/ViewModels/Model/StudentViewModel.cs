namespace StudentToolkit.MVVM.ViewModels.Model;

public sealed class StudentViewModel : ViewModel
{
    private string _firstName = string.Empty;
    private string _middlename = string.Empty;
    private string _lastName = string.Empty;

    public string FullName => $"{LastName} {FirstName} {MiddleName}";
    public string ShortFullName => $"{LastName} {FirstName[0]}. {MiddleName[0]}.";
    public Guid Id {  get; set; }

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
}
