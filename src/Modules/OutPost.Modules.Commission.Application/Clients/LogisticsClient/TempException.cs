using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Commission.Application.Clients.LogisticsClient;

public class TempException : CoreException
{
    public TempException(string text) : base(text)
    {
    }
}