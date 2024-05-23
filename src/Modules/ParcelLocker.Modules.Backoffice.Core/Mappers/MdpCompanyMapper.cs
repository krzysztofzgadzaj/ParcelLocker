using ParcelLocker.Modules.Backoffice.Core.DTO;
using ParcelLocker.Modules.Backoffice.Core.Entities;
using ParcelLocker.Modules.Backoffice.Core.Events.Internal;

namespace ParcelLocker.Modules.Backoffice.Core.Mappers;

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
