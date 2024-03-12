namespace StudentToolkit.MVVM.ViewModels.Components;

public sealed class StatusbarViewModel : ViewModel
{
    private string _groupCode = "-";
    private DateTime _currentDateTime;

    public StatusbarViewModel()
    {
        TimeService.TimerTickCallback += (currentDateTime) =>
        {
            CurrentDateTime = currentDateTime;
        };
    }

    public string GroupCode
    {
        get => _groupCode;
        set => Set(ref _groupCode, value);
    }
    public DateTime CurrentDateTime
    {
        get => _currentDateTime;
        set => Set(ref _currentDateTime, value);
    }
}
