using System.Runtime.InteropServices;

namespace StudentToolkit.WpfCore.Common.Interop.Structs;

[StructLayout(LayoutKind.Sequential)]
internal record struct IntRect(int Left, int Top, int Right, int Bottom);
