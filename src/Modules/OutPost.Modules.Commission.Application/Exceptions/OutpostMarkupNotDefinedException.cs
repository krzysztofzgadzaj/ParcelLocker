using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Commission.Application.Exceptions;

public class OutpostMarkupNotDefinedException : CoreException
{
    public OutpostMarkupNotDefinedException(string text) : base(text)
    {
    }
}
