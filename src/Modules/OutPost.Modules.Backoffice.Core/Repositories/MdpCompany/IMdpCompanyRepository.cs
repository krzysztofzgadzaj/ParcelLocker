namespace OutPost.Modules.Backoffice.Core.Repositories.MdpCompany;

public interface IMdpCompanyRepository
{
    Task<IEnumerable<Entities.MdpCompany>> Get();
    Task<Entities.MdpCompany?> GetById(Guid id);
    Task Create(Entities.MdpCompany mdpCompany);
}