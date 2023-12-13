namespace ParcelLocker.Modules.Storage.Core.Services;

internal interface IStorageService
{
    Task<Entities.Storage> GetByIdAsync(int id);
    Task CreateAsync(Entities.Storage storage);
}