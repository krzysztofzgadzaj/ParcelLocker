using ParcelLocker.Modules.Backoffice.Core.DTO;

namespace ParcelLocker.Modules.Backoffice.Core.Services.MdpCompany;

public interface IMdpCompanyService
{
    Task CreateMdpCompany(MdpCompanyDto mdpCompanyDto);
    Task<IEnumerable<MdpCompanyDto>> GetMdpCompanies();
}