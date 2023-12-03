namespace ParcelLocker.Shared.Abstractions.Exceptions;

public abstract class CoreException : Exception
{
    protected CoreException(string text) : base(text)
    {
    }
}