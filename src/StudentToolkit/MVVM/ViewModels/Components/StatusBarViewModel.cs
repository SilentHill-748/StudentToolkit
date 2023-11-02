using System;
using System.Windows.Threading;

namespace StudentToolkit.MVVM.ViewModels.Components;

public sealed class StatusBarViewModel : ViewModel
{
    private string _groupCode = "-";
    private DateTime _date;

    public StatusBarViewModel()
    {
        InitializeTimer();
    }

    public string GroupCode
    {
        get => _groupCode;
        set => Set(ref _groupCode, value);
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
