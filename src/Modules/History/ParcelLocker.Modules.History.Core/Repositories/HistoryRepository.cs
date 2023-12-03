using System.Collections.Concurrent;
using ParcelLocker.Modules.History.Core.Entities;

namespace ParcelLocker.Modules.History.Core.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private static readonly ConcurrentBag<HistoryLog> HistoryLogs = new();
    
    public Task AddHistoryLogAsync(HistoryLog historyLog)
    {
        HistoryLogs.Add(historyLog);
        
        return Task.CompletedTask;
    }

    public Task<HistoryLog> GetHistoryLogByIdAsync(int id)
    {
        return Task.FromResult(HistoryLogs.SingleOrDefault(x => x.Id == id));
    }
}