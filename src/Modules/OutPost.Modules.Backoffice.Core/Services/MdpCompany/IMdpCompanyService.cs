using OutPost.Modules.Backoffice.Core.DTO;

namespace OutPost.Modules.Backoffice.Core.Services.MdpCompany;

public interface IMdpCompanyService
{
    Task CreateMdpCompany(MdpCompanyDto mdpCompanyDto);
    Task<IEnumerable<MdpCompanyDto>> GetMdpCompanies();
}