using System.Collections.Generic;

namespace StudentToolkit.WpfCore.Exceptions;

public static class CustomExceptionMessages
{
    private static readonly Dictionary<Type, string> UserMessages = new();

    public static void Register<TException>(string userMessage)
    {
        ArgumentException.ThrowIfNullOrEmpty(userMessage, nameof(userMessage));

        var exType = typeof(TException);

        UserMessages[exType] = userMessage;
    }

    public static string GetMessage(Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception, nameof(exception));

        var exType = exception.GetType();

        if (UserMessages.TryGetValue(exType, out var message))
        {
            return message;
        }

        return $"Неизвестная ошибка типа '{exType.Name}' с сообщением:\n{exception.Message}";
    }
}
