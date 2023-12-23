using ParcelLocker.Shared.Abstractions.Exceptions.Types;

namespace ParcelLocker.Modules.Storage.Core.Exceptions;

public class IncorrectNameException : CoreException
{
    public IncorrectNameException(string text) : base(text)
    {
    }
}