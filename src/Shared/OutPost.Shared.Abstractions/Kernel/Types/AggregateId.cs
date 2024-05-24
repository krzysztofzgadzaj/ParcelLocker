namespace OutPost.Shared.Abstractions.Kernel.Types;

public class AggregateId<TKey> : IEquatable<AggregateId<TKey>>
{
    public TKey Value { get; set; }

    public AggregateId(TKey value)
    {
        Value = value;
    }

    public bool Equals(AggregateId<TKey> other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EqualityComparer<TKey>.Default.Equals(Value, other.Value);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((AggregateId<TKey>) obj);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<TKey>.Default.GetHashCode(Value);
    }
}

public class AggregateId : AggregateId<Guid>
{
    public AggregateId() : this(Guid.NewGuid())
    {
    }
        
    public AggregateId(Guid value) : base(value)
    {
    }

    public static implicit operator Guid(AggregateId id) => id.Value;
    public static implicit operator AggregateId(Guid id) => new(id);
}
