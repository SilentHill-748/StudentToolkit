namespace StudentToolkit.WpfCore.Common.Enums;

internal enum MonitorOptions : uint
{
    //Returns NULL.
    DefaultToNull = 0x00000000,

    //Returns a handle to the primary display monitor.
    DefaultToPrimary = 0x00000001,

    //Returns a handle to the display monitor that is nearest to the point.
    DefaultToNearest = 0x00000002
}
