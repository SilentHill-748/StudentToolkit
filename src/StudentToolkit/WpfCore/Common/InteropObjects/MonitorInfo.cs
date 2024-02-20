using System.Runtime.InteropServices;

namespace StudentToolkit.WpfCore.Common.InteropObjects;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
internal struct MonitorInfo()
{
    public int cbSize = Marshal.SizeOf<MonitorInfo>();
    public IntRect rcMonitor = new();
    public IntRect rcWork = new();
    public int dwFlags = 0;
}
