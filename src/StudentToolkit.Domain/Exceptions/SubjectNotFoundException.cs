namespace StudentToolkit.Domain.Exceptions;

public class SubjectNotFoundException : Exception
{
    public SubjectNotFoundException(Guid id)
    {
        Message = $"Subject was not found by key value! Key is {id}";
    }

    public override string Message { get; }
}
