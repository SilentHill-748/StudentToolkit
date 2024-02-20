using System.Runtime.InteropServices;

namespace StudentToolkit.WpfCore.Common.InteropObjects;

[StructLayout(LayoutKind.Sequential)]
internal record struct IntPoint(int X, int Y);
