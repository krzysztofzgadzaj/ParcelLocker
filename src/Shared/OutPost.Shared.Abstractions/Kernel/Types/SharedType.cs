namespace OutPost.Shared.Abstractions.Kernel.Types;

public abstract class SharedType<T> : IEquatable<SharedType<T>>
{
    public T Id { get; set; }

    protected SharedType(T id)
    {
        Id = id;
    }

    public bool Equals(SharedType<T> other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EqualityComparer<T>.Default.Equals(Id, other.Id);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((SharedType<T>) obj);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<T>.Default.GetHashCode(Id);
    }

    public static implicit operator T(SharedType<T> sharedType) => sharedType.Id;
}

public abstract class SharedType : SharedType<Guid>
{
    protected SharedType(Guid id) : base(id)
    {
    }

    public static bool operator ==(SharedType a, SharedType b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }

        if (a?.Id is not null && b?.Id is not null)
        {
            return a.Id.Equals(b.Id);
        }

        return false;
    }

    public static bool operator !=(SharedType a, SharedType b)
    {
        return !(a == b);
    }
}