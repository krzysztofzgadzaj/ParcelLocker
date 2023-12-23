namespace ParcelLocker.Modules.Storage.Core.Repositories;

internal interface IStorageRepository
{
    Task<Entities.Storage> GetByIdAsync(Guid id);
    Task CreateAsync(Entities.Storage storage);
    Task UpdateAsync(Guid id, Entities.Storage storage);
}