namespace StudentToolkit.WpfCore.Common.Interop.Structs;

internal readonly record struct IntMessageArgs(
    IntPtr Hwnd,
    IntPtr WordParameter,
    IntPtr LongParameter);
