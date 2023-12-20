namespace StudentToolkit.WpfCore.Exceptions;

public class ViewModelProviderNotSetException : Exception
{
    public override string Message => "ViewModel provider is null!";
}
