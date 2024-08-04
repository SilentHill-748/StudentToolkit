namespace StudentToolkit.Presentation.Common.Exceptions;

internal class BadCommandParameterException : Exception
{
    public BadCommandParameterException(Type expectedParamType)
        : base($"Command parameter is null or not '{expectedParamType.Name}'!")
    { }
}
