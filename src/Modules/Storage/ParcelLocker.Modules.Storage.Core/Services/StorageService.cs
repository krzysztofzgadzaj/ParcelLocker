using ParcelLocker.Modules.Storage.Core.Exceptions;
using ParcelLocker.Modules.Storage.Core.Repositories;

namespace ParcelLocker.Modules.Storage.Core.Services;

internal class StorageService : IStorageService
{
    private readonly IStorageRepository _storageRepository;

    public StorageService(IStorageRepository storageRepository)
    {
        _storageRepository = storageRepository;
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
    }
}