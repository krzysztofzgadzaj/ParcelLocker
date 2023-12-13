using ParcelLocker.Shared.Abstractions.Events;

namespace ParcelLocker.Modules.Storage.Contract.Events;

public record StorageCreated(int Id, string Name, int Load) : IEvent;
