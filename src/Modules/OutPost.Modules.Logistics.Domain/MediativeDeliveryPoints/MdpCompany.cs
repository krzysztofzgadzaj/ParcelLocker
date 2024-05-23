namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;

public class MdpCompany
{
    public MdpCompany(Guid id, string name, MdpTypes allowedMdpTypes)
    {
        if (id == Guid.Empty || string.IsNullOrEmpty(name))
        {
            throw new ArgumentException();
        }
        
        Id = id;
        Name = name;
        AllowedMdpTypes = allowedMdpTypes;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public MdpTypes AllowedMdpTypes { get; init; }

    public bool MdpTypeAllowed(MdpTypes mdpType)
        => (AllowedMdpTypes & mdpType) != MdpTypes.None;
}
