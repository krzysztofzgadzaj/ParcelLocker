using ParcelLocker.Modules.History.Core.DTO;

namespace ParcelLocker.Modules.History.Core.Services;

public interface IHistoryService
{
    Task<HistoryLogDto> GetLogByIdAsync(int id);
    Task CrateHistoryLogAsync(HistoryLogDto historyLogDto);
}
