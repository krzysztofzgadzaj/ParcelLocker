using ParcelLocker.Modules.Storage.Core.Events;
using ParcelLocker.Modules.Storage.Core.Exceptions;
using ParcelLocker.Modules.Storage.Core.Repositories;
using ParcelLocker.Shared.Infrastructure.Modules;

namespace ParcelLocker.Modules.Storage.Core.Services;

internal class StorageService : IStorageService
{
    private readonly IStorageRepository _storageRepository;
    private readonly IModuleClient _moduleClient;

    public StorageService(IStorageRepository storageRepository, IModuleClient moduleClient)
    {
        _storageRepository = storageRepository;
        _moduleClient = moduleClient;
    }

    public async Task<Entities.Storage> GetByIdAsync(int id)
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
        await _moduleClient.PublishAsync(new StorageCreated(storage.Id, storage.Name, storage.Load));
    }
}
