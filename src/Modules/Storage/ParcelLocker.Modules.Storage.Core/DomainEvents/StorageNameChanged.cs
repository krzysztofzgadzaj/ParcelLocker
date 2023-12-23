using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Storage.Core.DomainEvents;

public class StorageNameChanged : IDomainEvent
{
    public StorageNameChanged(Entities.Storage storage)
    {
        Storage = storage;
    }

    public Entities.Storage Storage { get; }
}