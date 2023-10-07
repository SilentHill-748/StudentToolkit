using System;
using System.Windows.Threading;

using StudentToolkit.MVVM.ViewModels.Model;

namespace StudentToolkit.MVVM.ViewModels.Components;

public sealed class StatusBarViewModel : ViewModel
{
    private readonly GroupViewModel _groupViewModel;
    private DateTime _date;

    public StatusBarViewModel(GroupViewModel groupViewModel)
    {
        _groupViewModel = groupViewModel;

        InitializeTimer();
    }

    public string GroupName => GetGroupName();

    public DateTime CurrentDate
    {
        get => _date;
        set => Set(ref _date, value);
    }

    private string GetGroupName()
    {
        var nameIsNullOrEmpty = string.IsNullOrEmpty(_groupViewModel.Name);

        return "Группа: " + (nameIsNullOrEmpty ? "-" : _groupViewModel.Name);
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
