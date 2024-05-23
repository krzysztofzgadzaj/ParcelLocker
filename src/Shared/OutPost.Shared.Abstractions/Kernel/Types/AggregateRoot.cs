namespace OutPost.Shared.Abstractions.Kernel.Types;

public abstract class AggregateRoot<TKey>
{
    private bool _versionUpdated;
    private readonly List<IDomainEvent> _domainEvents = new();

    public TKey Id { get; set; }
    public int Version { get; private set; }

    public IEnumerable<IDomainEvent> GetEvents => _domainEvents;
    
    public void AddEvent(IDomainEvent @event)
    {
        _domainEvents.Add(@event);
        IncrementVersion();
    }

    public void IncrementVersion()
    {
        if (_versionUpdated)
        {
            return;
        }
        
        Version++;
        _versionUpdated = true;
    }
}

public abstract class AggregateRoot : AggregateRoot<AggregateId>;
