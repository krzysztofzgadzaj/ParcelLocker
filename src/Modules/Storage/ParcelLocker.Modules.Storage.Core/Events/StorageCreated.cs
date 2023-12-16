using ParcelLocker.Shared.Abstractions.Events;

namespace ParcelLocker.Modules.Storage.Core.Events;

internal record StorageCreated(int Id, string Name, int Load) : IEvent;
