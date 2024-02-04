using StudentToolkit.Application.Common.Exceptions;

namespace StudentToolkit.Application.Extentions;

public static class ExceptionExtentions
{
    private const string EmptyMessage = "Occured an exception without a log message.";

    public static DataWrapperException WrapWithMessage(this Exception exception, string? message)
    {
        message = string.IsNullOrEmpty(message) ?
            EmptyMessage :
            message;

        return new DataWrapperException(message, exception);
    }

    public static bool IsWrapped(this Exception exception)
        => exception is DataWrapperException;

    public static bool IsNotWrapped(this Exception exception)
        => !IsWrapped(exception);
}
