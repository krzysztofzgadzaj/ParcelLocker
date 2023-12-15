using ParcelLocker.Modules.History.Core.DTO;

namespace ParcelLocker.Modules.History.Core.Services;

internal interface IHistoryService
{
    Task<HistoryLogDto> GetLogByIdAsync(int id);
    Task CrateHistoryLogAsync(HistoryLogDto historyLogDto);
}
