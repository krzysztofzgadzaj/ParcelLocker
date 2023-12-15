using ParcelLocker.Modules.History.Core.Entities;

namespace ParcelLocker.Modules.History.Core.Repositories;

internal interface IHistoryRepository
{
    Task AddHistoryLogAsync(HistoryLog historyLog);
    Task<HistoryLog> GetHistoryLogByIdAsync(int id);
}