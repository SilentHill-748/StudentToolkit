using System.Windows.Threading;

namespace StudentToolkit.WpfCore.Services;

public static class TimeService
{
    static TimeService()
    {
        CurrentDateTime = TimeProvider.System.GetLocalNow().DateTime;
        CurrentTime = TimeOnly.FromDateTime(CurrentDateTime);
        CurrentDate = DateOnly.FromDateTime(CurrentDateTime);

        InitializeTimer();
    }

    public static event Action<DateTime>? TimerTickCallback;

    public static DateTime CurrentDateTime { get; private set; }
    public static DateOnly CurrentDate { get; private set; }
    public static TimeOnly CurrentTime { get; private set; }

    public static bool IsOutdated(DateTime date)
    {
        return CurrentDateTime.Ticks > date.Ticks;
    }

    public static bool IsNotOutdated(DateTime date)
    {
        return !IsOutdated(date);
    }

    public static bool IsEarly(DateTime date)
    {
        return IsNotOutdated(date);
    }

    public static bool IsInRange(DateTime startDate, DateTime endDate)
    {
        return
            IsEarly(startDate) ||
            IsNotOutdated(endDate);
    }

    private static void InitializeTimer()
    {
        var tickTime = TimeSpan.FromSeconds(1);

        DispatcherTimer timer = new(DispatcherPriority.Render, App.Current.Dispatcher)
        {
            Interval = tickTime
        };

        timer.Tick += (s, e) =>
        {
            CurrentDate = DateOnly.FromDateTime(CurrentDateTime.Date);
            CurrentTime = CurrentTime.Add(tickTime);
            CurrentDateTime = CurrentDateTime.Add(tickTime);
            
            TimerTickCallback?.Invoke(CurrentDateTime);
        };

        timer.Start();
    }
}
