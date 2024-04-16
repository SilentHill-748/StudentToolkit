using System.Windows;
using System.Windows.Interop;

using StudentToolkit.WpfCore.Common.Interop.MessageHandlers;
using StudentToolkit.WpfCore.Common.Interop.Structs;

namespace StudentToolkit.WpfCore.Services;

public static class WindowInteropService
{
    private static readonly Dictionary<int, IMessageHandler> MessageHandlers = [];

    /// <summary>
    /// Register collection of <see cref="IMessageHandler"/> that does handle the WinAPI messages.
    /// </summary>
    /// <param name="messageHandlers">The collection of handlers.</param>
    internal static void RegisterHandlers(IEnumerable<IMessageHandler> messageHandlers)
    {
        foreach (IMessageHandler handler in messageHandlers)
        {
            MessageHandlers.TryAdd(handler.Message, handler);
        }
    }

    /// <summary>
    /// Remove all handlers.
    /// </summary>
    internal static void ClearHandlers()
    {
        MessageHandlers.Clear();
    }

    /// <summary>
    /// Set an event handler <see cref="HwndSourceHook"/> for specified <see cref="Window"/> instance.
    /// </summary>
    public static void AddWindowProcedureHook(Window window)
    {
        IntPtr handle = new WindowInteropHelper(window).Handle;

        HwndSource
            .FromHwnd(handle)
            .AddHook(WindowProcedure);
    }

    private static IntPtr WindowProcedure(
        IntPtr hwnd,
        int msg,
        IntPtr wParam,
        IntPtr lParam,
        ref bool handled)
    {
        if (MessageHandlers.TryGetValue(msg, out IMessageHandler? messageHandler))
        {
            IntMessageArgs args = new(hwnd, wParam, lParam);

            handled = messageHandler?.Handle(args) == true;
        }

        return IntPtr.Zero;
    }
}
