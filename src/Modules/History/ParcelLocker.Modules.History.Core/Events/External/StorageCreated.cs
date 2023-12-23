using ParcelLocker.Shared.Abstractions.Events;

namespace ParcelLocker.Modules.History.Core.Events.External;

internal record StorageCreated(Guid Id, string Name, int Load) : IEvent;
