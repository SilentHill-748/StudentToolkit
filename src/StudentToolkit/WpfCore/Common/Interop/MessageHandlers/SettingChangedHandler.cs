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
            IntPoint windowPositionPoint = GetWindowPosition(window);
            MonitorInfo monitorInfo = WinApiHelper.GetMonitorInfoFromPoint(windowPositionPoint);
            IntRect moveToArea = CalculateMoveWindowArea(monitorInfo.rcWork);

            WinApiHelper.MoveWindow(args.Hwnd, moveToArea);
        }

        return true;
    }

    private static IntPoint GetWindowPosition(Window window)
    {
        return new IntPoint(
            (int)window.Left,
            (int)window.Top);
    }

    private static IntRect CalculateMoveWindowArea(IntRect workArea)
    {
        return new IntRect()
        {
            Left = workArea.Left,
            Top = workArea.Top,
            Right = Math.Abs(workArea.Right - workArea.Left),
            Bottom = Math.Abs(workArea.Bottom - workArea.Top)
        };
    }
}
