namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Repositories;

public interface IMdpCompanyRepository
{
    Task Add(MdpCompany mdpCompany);
    Task<MdpCompany?> GetById(Guid id);
    Task<IEnumerable<MdpCompany>> GetMdpCompanies();
}
