using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;

public class MdpCompanyDto
{
    public MdpCompanyDto()
    {
    }

    public MdpCompanyDto(MdpCompany mdpCompany)
    {
        Id = mdpCompany.Id;
        Name = mdpCompany.Name;
        AllowedMdpTypes = mdpCompany.AllowedMdpTypes;
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public MdpTypes AllowedMdpTypes { get; set; }
}
