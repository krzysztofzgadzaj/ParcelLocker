namespace OutPost.Modules.Logistics.Domain.Shared;

public class Deadline
{
    public Deadline(DateTime deadline)
    {
        DeadlineTime = deadline;
    }
    
    public DateTime DeadlineTime { get; init; }
}
