using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;

namespace Outpost.Modules.Logistics.Tests.Builders;

public class MdpCompanyBuilder
{
    private string? _name;
    private MdpTypes? _allowedMdpTypes;

    public MdpCompanyBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
    
    public MdpCompanyBuilder WithAllowedMdpTypes(MdpTypes allowedMdpTypes)
    {
        _allowedMdpTypes = allowedMdpTypes;
        return this;
    }

    public MdpCompany Build()
    {
        var name = _name ?? "Mdp Company";
        var allowedMdpTypes = _allowedMdpTypes ?? MdpTypes.All;

        return new MdpCompany(Guid.NewGuid(), name, allowedMdpTypes);
    }
}
