using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;

using StudentToolkit.WpfCore.Common.Helpers;
using StudentToolkit.WpfCore.Common.Interop.Structs;

namespace StudentToolkit.WpfCore.Common.Interop.MessageHandlers;

internal class MinMaxInfoHandler : IMessageHandler
{
    public int Message => 0x24;

    public bool Handle(IntMessageArgs args)
    {
        IntPoint mousePosition = WinApiHelper.GetCursorPosition();
        MonitorInfo primaryScreenInfo = WinApiHelper.GetMonitorInfoFromPoint(new IntPoint(), MonitorOptions.DefaultToPrimary);
        MonitorInfo currentScreenInfo = WinApiHelper.GetMonitorInfoFromPoint(mousePosition);
        MinMaxInfo minMaxInfo = Marshal.PtrToStructure<MinMaxInfo>(args.LongParameter);

        minMaxInfo.PointMaxSize = CalculateMaxSize(primaryScreenInfo, currentScreenInfo);
        minMaxInfo.PointMaxPosition = CalculateMaxPosition(primaryScreenInfo);
        minMaxInfo.PointMinTrackSize = CalculateMinTrackSize(args.Hwnd);
        minMaxInfo.PointMaxTrackSize.Y = CalculateMaxTrackHeight(currentScreenInfo);

        Marshal.StructureToPtr(minMaxInfo, args.LongParameter, true);
        
        return true;
    }

    private static IntPoint CalculateMaxSize(
        MonitorInfo primaryScreenInfo,
        MonitorInfo currentScreenInfo)
    {
        int workHeight = Math.Abs(currentScreenInfo.rcWork.Bottom - currentScreenInfo.rcWork.Top);
        int workWidth = Math.Min(
                Math.Abs(currentScreenInfo.rcWork.Right - currentScreenInfo.rcWork.Left),
                Math.Abs(primaryScreenInfo.rcWork.Right - primaryScreenInfo.rcWork.Left));

        return new IntPoint(workWidth, workHeight);
    }

    private static IntPoint CalculateMaxPosition(MonitorInfo primaryScreenInfo)
    {
        int left = primaryScreenInfo.rcWork.Left;
        int top = primaryScreenInfo.rcWork.Top;

        return new IntPoint(left, top);
    }

    private static int CalculateMaxTrackHeight(MonitorInfo currentScreenInfo)
    {
        return currentScreenInfo.rcWork.Bottom;
    }

    private static IntPoint CalculateMinTrackSize(IntPtr hwnd)
    {
        Window window = WinApiHelper.GetWindowFromHandle(hwnd);
        CompositionTarget compositionTarget = GetCompositionTarget(window);

        Point scaleFactor = new(
            compositionTarget.TransformToDevice.M11,
            compositionTarget.TransformToDevice.M22);

        int minWidth = (int)(window.MinWidth * scaleFactor.X);
        int minHeight = (int)(window.MinHeight * scaleFactor.Y);

        return new IntPoint(minWidth, minHeight);
    }

    private static CompositionTarget GetCompositionTarget(Window visual)
    {
        return PresentationSource
            .FromVisual(visual)
            .CompositionTarget;
    }
}
