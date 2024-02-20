using System.Runtime.InteropServices;

namespace StudentToolkit.WpfCore.Common.InteropObjects;

[StructLayout(LayoutKind.Sequential)]
internal record struct IntRect(int Left, int Top, int Right, int Bottom);
