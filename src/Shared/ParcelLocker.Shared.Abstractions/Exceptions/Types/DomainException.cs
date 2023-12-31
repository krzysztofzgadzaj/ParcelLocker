namespace ParcelLocker.Shared.Abstractions.Exceptions.Types;

public abstract class DomainException : Exception
{
    public DomainException(string text) : base(text)
    {
    }
}
