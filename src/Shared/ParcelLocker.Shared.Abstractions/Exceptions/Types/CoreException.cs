namespace ParcelLocker.Shared.Abstractions.Exceptions.Types;

public abstract class CoreException : Exception
{
    protected CoreException(string text) : base(text)
    {
    }
}
