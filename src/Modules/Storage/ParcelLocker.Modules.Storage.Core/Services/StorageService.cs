using ParcelLocker.Modules.Storage.Core.Events;
using ParcelLocker.Modules.Storage.Core.Exceptions;
using ParcelLocker.Modules.Storage.Core.Repositories;
using ParcelLocker.Shared.Abstractions.Kernel;
using ParcelLocker.Shared.Abstractions.Messaging;

namespace ParcelLocker.Modules.Storage.Core.Services;

internal class StorageService : IStorageService
{
    private readonly IStorageRepository _storageRepository;
    private readonly IMessageBroker _messageBroker;
    private readonly IDomainEventDispatcher _domainEventDispatcher;

    public StorageService(IStorageRepository storageRepository, IMessageBroker messageBroker, IDomainEventDispatcher domainEventDispatcher)
    {
        _storageRepository = storageRepository;
        _messageBroker = messageBroker;
        _domainEventDispatcher = domainEventDispatcher;
    }

    public async Task<Entities.Storage> GetByIdAsync(Guid id)
    {
        var storage =  await _storageRepository.GetByIdAsync(id);

        if (storage is null)
        {
            throw new StorageNotFoundException($"Storage with id {id} was nat found");
        }

        return storage;
    }

    public async Task CreateAsync(Entities.Storage storage)
    {
        await _storageRepository.CreateAsync(storage);
        await _messageBroker.PublishAsync(new StorageCreated(storage.Id, storage.Name, storage.Load));
    }

    public async Task UpdateAsync(Guid id)
    {
        var storage =  await _storageRepository.GetByIdAsync(id);

        if (storage is null)
        {
            throw new StorageNotFoundException($"Storage with id {id} was nat found");
        }
        
        storage.UpdateLoad(5);
        storage.UpdateName("Version another");
        await _storageRepository.UpdateAsync(id, storage);
        await _domainEventDispatcher.PublishAsync(storage.GetEvents.ToArray()); 
    }
}
