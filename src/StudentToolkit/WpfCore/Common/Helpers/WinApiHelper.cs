using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

using StudentToolkit.WpfCore.Common.Interop.Structs;

namespace StudentToolkit.WpfCore.Common.Helpers;

internal partial class WinApiHelper
{
    public static Window GetWindowFromHandle(IntPtr hwnd)
    {
        Visual visualRoot = HwndSource.FromHwnd(hwnd).RootVisual;

        if (visualRoot is Window window)
            return window;

        throw new NotWindowHandleException(hwnd);
    }

    public static IntPoint GetCursorPosition()
    {
        GetCursorPos(out IntPoint position);
        
        return position;
    }

    public static MonitorInfo GetMonitorInfoFromPoint(IntPoint point, MonitorOptions options = MonitorOptions.DefaultToNearest)
    {
        MonitorInfo monitorInfo = new();
        IntPtr monitor = MonitorFromPoint(point, options);

        GetMonitorInfo(monitor, ref monitorInfo);

        return monitorInfo;
    }

    public static void MoveWindow(IntPtr hwnd, int x, int y, int width, int height)
    {
        MoveWindow(hwnd, x, y, width, height, true);
    }

    public static Rect GetCurrentMonitorArea()
    {
        GetCursorPos(out IntPoint mousePosition);

        MonitorInfo monitorInfo = GetMonitorInfoFromPoint(mousePosition, MonitorOptions.DefaultToNearest);

        IntRect monitorSize = monitorInfo.rcWork;

        return new Rect(
            monitorSize.Left,
            monitorSize.Top,
            monitorSize.Right - monitorSize.Left,
            monitorSize.Bottom - monitorSize.Top);
    }

    public static Point GetMousePositionToScreen()
    {
        IntPoint point = GetCursorPosition();

        return new Point(point.X, point.Y);
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
        [MarshalAs(UnmanagedType.Bool)] bool bRepaint);
    #endregion
}
