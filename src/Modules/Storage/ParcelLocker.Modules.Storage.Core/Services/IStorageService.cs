namespace ParcelLocker.Modules.Storage.Core.Services;

internal interface IStorageService
{
    Task<Entities.Storage> GetByIdAsync(Guid id);
    Task CreateAsync(Entities.Storage storage);
    Task UpdateAsync(Guid id);
}