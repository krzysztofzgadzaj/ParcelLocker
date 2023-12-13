using System.Collections.Concurrent;

namespace ParcelLocker.Modules.Storage.Core.Repositories;

internal class StorageRepository : IStorageRepository
{
    private static readonly ConcurrentBag<Entities.Storage> Storages = new();
    
    public async Task<Entities.Storage> GetByIdAsync(int id)
    {
        return Storages.FirstOrDefault(x => x.Id == id);
    }

    public async Task CreateAsync(Entities.Storage storage)
    {
        Storages.Add(storage);
    }
}