namespace StudentToolkit.MVVM.ViewModels.Model;

public sealed class TeacherViewModel : ViewModel
{
    private string _firstName = string.Empty;
    private string _middlename = string.Empty;
    private string _lastName = string.Empty;

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

    public override string ToString()
    {
        var shortFirstName = FirstName.Length > 0 ? '\0' : FirstName[0];
        var shortLastName = LastName.Length > 0 ? '\0' : LastName[0];

        return $"{MiddleName} {shortFirstName}. {shortLastName}.";
    }
}
