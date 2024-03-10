using System.Windows.Threading;

namespace StudentToolkit.MVVM.ViewModels.Components;

public sealed class StatusbarViewModel : ViewModel
{
    private string _groupCode = "-";
    private DateTime _currentDateTime;

    public StatusbarViewModel()
    {
        InitializeTimer();
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

    private void InitializeTimer()
    {
        CurrentDateTime = DateTime.Now;

        var timer = new DispatcherTimer(DispatcherPriority.Render, App.Current.Dispatcher)
        {
            Interval = TimeSpan.FromSeconds(1)
        };

        timer.Tick += (s, e) => { CurrentDateTime = CurrentDateTime.AddSeconds(1); };
        timer.Start();
    }
}
