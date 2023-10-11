using System;
using System.Windows.Threading;

namespace StudentToolkit.MVVM.ViewModels.Components;

public sealed class StatusBarViewModel : ViewModel
{
    private string _groupName = string.Empty;
    private DateTime _date;

    public StatusBarViewModel()
    {
        InitializeTimer();
    }

    public string GroupName
    {
        get => string.IsNullOrWhiteSpace(_groupName) ? "-" : _groupName;
        set => Set(ref _groupName, value);
    }
    public DateTime CurrentDate
    {
        get => _date;
        set => Set(ref _date, value);
    }

    private void InitializeTimer()
    {
        CurrentDate = DateTime.Now;

        var timer = new DispatcherTimer(DispatcherPriority.Render, App.Current.Dispatcher)
        {
            Interval = TimeSpan.FromSeconds(1)
        };

        timer.Tick += (s, e) => { CurrentDate = CurrentDate.AddSeconds(1); };
        timer.Start();
    }
}
