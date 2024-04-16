namespace StudentToolkit.WpfCore.Exceptions;

public class NotWindowHandleException : Exception
{
    public NotWindowHandleException(IntPtr hwnd)
    {
        Message = $"This pointer '{hwnd}' with name '{nameof(hwnd)}' not point to window!";
    }

    public override string Message { get; }
}
