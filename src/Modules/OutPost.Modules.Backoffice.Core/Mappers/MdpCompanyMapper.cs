using OutPost.Modules.Backoffice.Core.DTO;
using OutPost.Modules.Backoffice.Core.Entities;
using OutPost.Modules.Backoffice.Core.Events.Internal;

namespace OutPost.Modules.Backoffice.Core.Mappers;

public static class MdpCompanyMapper
{
    public static MdpCompany MapToMdpCompany(this MdpCompanyDto mdpCompanyDto) 
        => new (mdpCompanyDto.Name, mdpCompanyDto.MarkupPercentage, mdpCompanyDto.MdpTypes);

    public static MdpCompanyDto MapToDto(this MdpCompany mdpCompany)
        => new()
        {
            Name = mdpCompany.Name, 
            MarkupPercentage = mdpCompany.MarkupPercentage,
            MdpTypes = mdpCompany.MdpTypes
        };

    public static MdpCompanyCreated MapToEvent(this MdpCompany mdpCompany)
        => new (mdpCompany.Id.Id, mdpCompany.MarkupPercentage, mdpCompany.Name, mdpCompany.MdpTypes);
}
