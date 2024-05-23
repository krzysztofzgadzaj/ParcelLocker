using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints;
using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;

namespace ParcelLocker.Modules.Logistics.Infrastructure.Repositories;

public class MdpCompanyRepository : IMdpCompanyRepository
{
    private readonly List<MdpCompany> _mdpCompanies = new ();
    
    public async Task Add(MdpCompany mdpCompany)
    {
        _mdpCompanies.Add(mdpCompany);
    }

    public async Task<MdpCompany?> GetById(MdpCompanyId id)
    {
        return _mdpCompanies.FirstOrDefault(x => x.Id == id);
    }

    public async Task<IEnumerable<MdpCompany>> GetMdpCompanies()
        => _mdpCompanies;
}
