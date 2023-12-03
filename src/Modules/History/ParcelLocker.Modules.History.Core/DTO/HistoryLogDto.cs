namespace ParcelLocker.Modules.History.Core.DTO;

public class HistoryLogDto
{
    public HistoryLogDto()
    {
    }

    public HistoryLogDto(int id, string message)
    {
        Id = id;
        Message = message;
    }

    public int Id { get; set; }
    public string Message { get; set; }
}