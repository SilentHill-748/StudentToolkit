using System.Runtime.InteropServices;

namespace StudentToolkit.WpfCore.Common.InteropObjects;

[StructLayout(LayoutKind.Sequential)]
internal struct MinMaxInfo
{
    public IntPoint PointReserved;
    public IntPoint PointMaxSize;
    public IntPoint PointMaxPosition;
    public IntPoint PointMinTrackSize;
    public IntPoint PointMaxTrackSize;
}
