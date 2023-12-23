using ParcelLocker.Shared.Abstractions.Events;

namespace ParcelLocker.Modules.Storage.Core.Events;

internal record StorageCreated(Guid Id, string Name, int Load) : IEvent;
