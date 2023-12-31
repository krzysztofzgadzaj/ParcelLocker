using ParcelLocker.Shared.Abstractions.Exceptions.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Exceptions;

public class StoringSpotIsFullException : DomainException
{
    public StoringSpotIsFullException(string text) : base(text)
    {
    }
}