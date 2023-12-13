using ParcelLocker.Shared.Abstractions.Exceptions.Types;

namespace ParcelLocker.Modules.Storage.Core.Exceptions;

internal class StorageNotFoundException : NotFoundException
{
    public StorageNotFoundException(string text) : base(text)
    {
    }
}