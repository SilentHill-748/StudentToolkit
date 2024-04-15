using System.Runtime.InteropServices;

namespace StudentToolkit.WpfCore.Common.Interop.Structs;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
internal struct MonitorInfo()
{
    public int cbSize = Marshal.SizeOf<MonitorInfo>();
    public IntRect rcMonitor = new();
    public IntRect rcWork = new();
    public int dwFlags = 0;
}
