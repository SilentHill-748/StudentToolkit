using System.Windows;

using StudentToolkit.WpfCore.Common.Helpers;
using StudentToolkit.WpfCore.Common.Interop.Structs;

namespace StudentToolkit.WpfCore.Common.Interop.MessageHandlers;

internal class SettingChangedHandler : IMessageHandler
{
    public int Message => 0x1A;

    public bool Handle(IntMessageArgs args)
    {
        Window window = WinApiHelper.GetWindowFromHandle(args.Hwnd);

        if (window.WindowState == WindowState.Maximized)
        {
            IntPoint mousePosition = WinApiHelper.GetCursorPosition();
            MonitorInfo monitorInfo = WinApiHelper.GetMonitorInfoFromPoint(mousePosition);

            MoveWindow(args.Hwnd, monitorInfo.rcWork);
        }

        return true;
    }

    private static void MoveWindow(IntPtr hwnd, IntRect workArea)
    {
        int top = workArea.Top;
        int left = workArea.Left;
        int width = Math.Abs(workArea.Right - workArea.Left);
        int height = Math.Abs(workArea.Bottom - workArea.Top);

        WinApiHelper.MoveWindow(hwnd, left, top, width, height);
    }
}
