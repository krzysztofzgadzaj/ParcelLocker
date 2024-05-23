namespace OutPost.Shared.Abstractions.Kernel.Types;

public class SampleSharedType : SharedType
{
    public SampleSharedType(Guid id) : base(id)
    {
    }

    public static implicit operator SampleSharedType(Guid key) => new SampleSharedType(key);
}
