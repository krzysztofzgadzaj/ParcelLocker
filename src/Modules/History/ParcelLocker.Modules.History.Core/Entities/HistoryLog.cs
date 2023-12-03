namespace ParcelLocker.Modules.History.Core.Entities;

public class HistoryLog
{
    public HistoryLog()
    {
    }

    public HistoryLog(int id, string message)
    {
        Id = id;
        Message = message;
    }

    public int Id { get; set; }
    public string Message { get; set; }
}