﻿using ParcelLocker.Modules.History.Core.Entities;
using ParcelLocker.Modules.History.Core.Repositories;
using ParcelLocker.Shared.Abstractions.Events;

namespace ParcelLocker.Modules.History.Core.Events.External.Handlers;

internal class StorageCreatedEventHandler : IEventHandler<StorageCreated>
{
    private readonly IHistoryRepository _historyRepository;

    public StorageCreatedEventHandler(IHistoryRepository historyRepository)
    {
        _historyRepository = historyRepository;
    }

    public async Task HandleAsync(StorageCreated @event)
    {
        var historyLog = new HistoryLog(Random.Shared.Next(), $"StorageId: {@event.Id}, name: {@event.Name}, load: {@event.Load}");
        await _historyRepository.AddHistoryLogAsync(historyLog);
    }
}
