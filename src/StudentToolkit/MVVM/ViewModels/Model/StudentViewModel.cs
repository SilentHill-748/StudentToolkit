namespace StudentToolkit.MVVM.ViewModels.Model;

public sealed class StudentViewModel : ViewModel
{
    private string _firstName = string.Empty;
    private string _middlename = string.Empty;
    private string _lastName = string.Empty;
    private GroupViewModel? _groupViewModel;

    public StudentViewModel()
    {
        PropertyChanged += StudentViewModel_PropertyChanged; ;
    }

    public string FullName => $"{MiddleName} {FirstName} {LastName}";
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
    public GroupViewModel? Group
    {
        get => _groupViewModel;
        set => Set(ref _groupViewModel, value);
    }

    private void StudentViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        OnPropertyChanged(nameof(FullName));
        OnPropertyChanged(nameof(ShortFullName));
    }
}
