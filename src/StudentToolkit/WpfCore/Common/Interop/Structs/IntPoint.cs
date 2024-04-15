using System.Runtime.InteropServices;

namespace StudentToolkit.WpfCore.Common.Interop.Structs;

[StructLayout(LayoutKind.Sequential)]
internal record struct IntPoint(int X, int Y);
