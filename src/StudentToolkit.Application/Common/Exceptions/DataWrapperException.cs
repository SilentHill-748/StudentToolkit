using System.Collections;
using System.Text;

namespace StudentToolkit.Application.Common.Exceptions;

public class DataWrapperException : Exception
{
    public DataWrapperException() : base() { }
    public DataWrapperException(string? message) : base(message) { }
    public DataWrapperException(string? message, Exception? innerException) : base(message, innerException) { }

    public DataWrapperException SetDetail(string key, object value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key, nameof(key));
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        if (!Data.Contains(key))
        {
            Data.Add(key, value);
        }

        return this;
    }

    public string GetMessageWithData()
    {
        var exceptionDataStr = GetDataAsString();

        return string.IsNullOrEmpty(exceptionDataStr) ?
            Message :
            $"{Message}\n{exceptionDataStr}";
    }

    private string GetDataAsString()
    {
        if (Data.Count <= 1)
            return string.Empty;

        StringBuilder sb = new("Exception data");

        foreach (DictionaryEntry entry in Data)
        {
            // First item always is [System.Object] - [null].
            if (entry.Value is not null)
            {
                sb.Append($"\n\t{entry.Key}: \'{entry.Value}\'");
            }
        }

        return sb.ToString();
    }
}
