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
            Rect workArea = WinApiHelper.GetCurrentMonitorArea();
            IntRect moveToArea = CalculateMoveWindowArea(workArea);

            WinApiHelper.MoveWindow(args.Hwnd, moveToArea);
        }

        return true;
    }

    private static IntRect CalculateMoveWindowArea(Rect workArea)
    {
        return new IntRect()
        {
            Left = (int)workArea.X,
            Top = (int)workArea.Y,
            Right = (int)workArea.Width,
            Bottom = (int)workArea.Height
        };
    }
}
