using ParcelLocker.Shared.Abstractions.Events;

namespace ParcelLocker.Modules.History.Core.Events.External;

public record StorageCreated(int Id, string Name, int Load) : IEvent;
