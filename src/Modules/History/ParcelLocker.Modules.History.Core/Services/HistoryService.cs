using ParcelLocker.Modules.History.Core.DTO;
using ParcelLocker.Modules.History.Core.Entities;
using ParcelLocker.Modules.History.Core.Exceptions;
using ParcelLocker.Modules.History.Core.Repositories;

namespace ParcelLocker.Modules.History.Core.Services;

public class HistoryService(IHistoryRepository historyRepository) : IHistoryService
{
    public async Task<HistoryLogDto> GetLogByIdAsync(int id)
    {
        var historyLog = await historyRepository.GetHistoryLogByIdAsync(id);

        if (historyLog is null)
        {
            throw new HistoryLogNotFoundException(id);
        }

        return new HistoryLogDto(historyLog.Id, historyLog.Message);
    }

    public async Task CrateHistoryLogAsync(HistoryLogDto historyLogDto)
    {
        var historyLog = new HistoryLog(historyLogDto.Id, historyLogDto.Message);
        await historyRepository.AddHistoryLogAsync(historyLog);
    }
}
