using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Storage.Core.DomainEvents;

public class StorageLoadChanged : IDomainEvent
{
    public StorageLoadChanged(Entities.Storage storage)
    {
        Storage = storage;
    }

    public Entities.Storage Storage { get; }
}