using System.Diagnostics;

using StudentToolkit.Application.Common.Exceptions;

namespace StudentToolkit.Application.Extentions;

public static class ExceptionExtensions
{
    private const string EmptyMessage = "Occured an exception without a log message.";

    public static DataWrapperException WrapWithMessage(this Exception exception, string? message)
    {
        message = string.IsNullOrEmpty(message) ?
            EmptyMessage :
            message;

        return new DataWrapperException(message, exception)
            .SetDetail("Source", exception.GetExceptionSourceFilename());
    }

    public static bool IsWrapped(this Exception exception)
        => exception is DataWrapperException;

    public static bool IsNotWrapped(this Exception exception)
        => !IsWrapped(exception);

    internal static string GetExceptionSourceFilename(this Exception exception)
    {
        StackTrace stackTrace = new(exception, true);

        return GetFilenameFromStackFrame(stackTrace);
    }

    private static string GetFilenameFromStackFrame(StackTrace stackTrace)
    {
        string appName = "StudentToolkit";

        foreach (StackFrame frame in stackTrace.GetFrames())
        {
            string? filename = frame.GetFileName();

            if (filename is not null)
            {
                if (filename.Contains(appName))
                {
                    return Path.GetFileName(filename);
                }
            }
        }

        return "Unknown";
    }
}
