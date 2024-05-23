namespace OutPost.Shared.Abstractions.Exceptions.Types;

public abstract class NotFoundException : Exception
{
    protected NotFoundException(string text) : base(text)
    {
    }
}
