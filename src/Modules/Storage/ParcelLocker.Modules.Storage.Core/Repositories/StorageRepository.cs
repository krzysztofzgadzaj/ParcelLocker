namespace ParcelLocker.Modules.Storage.Core.Repositories;

internal class StorageRepository : IStorageRepository
{
    private static readonly List<Entities.Storage> Storages = new();
    
    public async Task<Entities.Storage> GetByIdAsync(Guid id)
    {
        return Storages.FirstOrDefault(x => x.Id == id);
    }

    public async Task CreateAsync(Entities.Storage storage)
    {
        Storages.Add(storage);
    }

    public async Task UpdateAsync(Guid id, Entities.Storage storage)
    {
        Storages.Remove(Storages.FirstOrDefault(x => x.Id == id));
        Storages.Add(storage);
    }
}