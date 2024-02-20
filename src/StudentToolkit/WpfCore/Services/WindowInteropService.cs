using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

using StudentToolkit.WpfCore.Common.InteropObjects;

namespace StudentToolkit.WpfCore.Services;

public partial class WindowInteropService
{
    private readonly Window _window;

    public WindowInteropService(Window window)
    {
        ArgumentNullException.ThrowIfNull(window, nameof(window));

        _window = window;
    }

    /// <summary>
    /// Set a new sizes for minimize and maximize specified window by changing of <see cref="Window.WindowState"/>.
    /// </summary>
    public void AddWindowProcedureHook()
    {
        IntPtr handle = new WindowInteropHelper(_window).Handle;

        HwndSource
            .FromHwnd(handle)
            .AddHook(WindowProcedure);
    }

    private IntPtr WindowProcedure(
        IntPtr hwnd,
        int msg,
        IntPtr wParam,
        IntPtr lParam,
        ref bool handled)
    {
        switch (msg)
        {
            case 0x0024:
                GetMinMaxInfo(lParam);
                handled = true;
                break;
            case 0x001A:
                SettingChanged(hwnd);
                handled = true;
                break;
        }

        return IntPtr.Zero;
    }

    private void SettingChanged(IntPtr hwnd)
    {
        if (_window.WindowState == WindowState.Maximized)
        {
            GetCursorPos(out IntPoint mousePosition);

            MonitorInfo monitorInfo = GetMonitorInfoFromPoint(mousePosition, MonitorOptions.DefaultToNearest);

            var workArea = monitorInfo.rcWork;

            int top = workArea.Top;
            int left = workArea.Left;
            int width = Math.Abs(workArea.Right - workArea.Left);
            int height = Math.Abs(workArea.Bottom - workArea.Top);

            MoveWindow(hwnd, left, top, width, height, true);
        }
    }

    private void GetMinMaxInfo(IntPtr lParam)
    {
        GetCursorPos(out IntPoint mousePosition);

        MonitorInfo primaryScreenInfo = GetMonitorInfoFromPoint(new IntPoint(), MonitorOptions.DefaultToPrimary);
        MonitorInfo currentScreenInfo = GetMonitorInfoFromPoint(mousePosition, MonitorOptions.DefaultToNearest);

        MinMaxInfo minMaxInfo = Marshal.PtrToStructure<MinMaxInfo>(lParam);

        CalculateSize(ref minMaxInfo, primaryScreenInfo, currentScreenInfo);

        Marshal.StructureToPtr(minMaxInfo, lParam, true);
    }

    private static MonitorInfo GetMonitorInfoFromPoint(IntPoint point, MonitorOptions options)
    {
        MonitorInfo monitorInfo = new();
        IntPtr monitor = MonitorFromPoint(point, options);

        GetMonitorInfo(monitor, ref monitorInfo);

        return monitorInfo;
    }

    private void CalculateSize(ref MinMaxInfo minMaxInfo, MonitorInfo primaryScreenInfo, MonitorInfo currentScreenInfo)
    {
        int workWidth = Math.Min(
            Math.Abs(currentScreenInfo.rcWork.Right - currentScreenInfo.rcWork.Left),
            Math.Abs(primaryScreenInfo.rcWork.Right - primaryScreenInfo.rcWork.Left));

        minMaxInfo.PointMaxPosition.X = primaryScreenInfo.rcWork.Left;
        minMaxInfo.PointMaxPosition.Y = primaryScreenInfo.rcWork.Top;

        minMaxInfo.PointMaxSize.X = workWidth;
        minMaxInfo.PointMaxSize.Y = Math.Abs(currentScreenInfo.rcWork.Bottom - currentScreenInfo.rcWork.Top);
        minMaxInfo.PointMaxTrackSize.Y = currentScreenInfo.rcWork.Bottom;

        SetMinSize(ref minMaxInfo);
    }

    private void SetMinSize(ref MinMaxInfo minMaxInfo)
    {
        var compositionTarget = PresentationSource.FromVisual(_window).CompositionTarget;

        Point scaleFactor = new(
            compositionTarget.TransformToDevice.M11,
            compositionTarget.TransformToDevice.M22);

        int minWidth = (int)(_window.MinWidth * scaleFactor.X);
        int minHeight = (int)(_window.MinHeight * scaleFactor.Y);

        minMaxInfo.PointMinTrackSize = new IntPoint(minWidth, minHeight);
    }

    #region Library imports
    [LibraryImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool GetCursorPos(out IntPoint lpPoint);

    [LibraryImport("user32.dll", EntryPoint = "GetMonitorInfoA", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool GetMonitorInfo(IntPtr hMonitor, ref MonitorInfo lpmi);

    [LibraryImport("user32.dll", SetLastError = true)]
    private static partial IntPtr MonitorFromPoint(IntPoint pt, MonitorOptions dwFlags);

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool MoveWindow(
        IntPtr hwnd,
        int x,
        int y,
        int nWidth,
        int nHeight,
        [MarshalAs(UnmanagedType.Bool)]bool bRepaint);
    #endregion
}
