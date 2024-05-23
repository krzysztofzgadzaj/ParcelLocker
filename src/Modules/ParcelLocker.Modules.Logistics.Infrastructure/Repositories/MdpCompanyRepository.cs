using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints;
using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;

namespace ParcelLocker.Modules.Logistics.Infrastructure.Repositories;

public class MdpCompanyRepository : IMdpCompanyRepository
{
    private readonly List<MdpCompany> _mdpCompanies = new ()
    {
        new MdpCompany(new MdpCompanyId(Guid.NewGuid()), "ParcelLocker", MdpTypes.ParcelLocker),
        new MdpCompany(new MdpCompanyId(Guid.NewGuid()), "ShoppingPoint", MdpTypes.ShoppingPoint),
        new MdpCompany(new MdpCompanyId(Guid.NewGuid()), "Both", MdpTypes.ParcelLocker | MdpTypes.ShoppingPoint),
    };
    
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
