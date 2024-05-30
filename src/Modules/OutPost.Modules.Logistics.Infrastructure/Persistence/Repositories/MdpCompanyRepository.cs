using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Repositories;

namespace OutPost.Modules.Logistics.Infrastructure.Persistence.Repositories;

public class MdpCompanyRepository : IMdpCompanyRepository
{
    private readonly List<MdpCompany> _mdpCompanies = new();
    
    public async Task Add(MdpCompany mdpCompany)
    {
        _mdpCompanies.Add(mdpCompany);
    }

    public async Task<MdpCompany?> GetById(Guid id)
    {
        return _mdpCompanies.FirstOrDefault(x => x.Id == id);
    }

    public async Task<IEnumerable<MdpCompany>> GetMdpCompanies()
        => _mdpCompanies;
}
