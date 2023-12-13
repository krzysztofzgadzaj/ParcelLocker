namespace ParcelLocker.Modules.Storage.Core.Repositories;

internal interface IStorageRepository
{
    Task<Entities.Storage> GetByIdAsync(int id);
    Task CreateAsync(Entities.Storage storage);
}