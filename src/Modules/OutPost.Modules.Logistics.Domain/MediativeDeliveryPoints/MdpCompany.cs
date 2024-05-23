namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;

public class MdpCompany
{
    public MdpCompany(MdpCompanyId id, string name, MdpTypes allowedMdpTypes)
    {
        if (id is null || string.IsNullOrEmpty(name))
        {
            throw new ArgumentException();
        }
        
        Id = id;
        Name = name;
        AllowedMdpTypes = allowedMdpTypes;
    }

    public MdpCompanyId Id { get; init; }
    public string Name { get; init; }
    public MdpTypes AllowedMdpTypes { get; init; }

    public bool MdpTypeAllowed(MdpTypes mdpType)
        => (AllowedMdpTypes & mdpType) != MdpTypes.None;
}
