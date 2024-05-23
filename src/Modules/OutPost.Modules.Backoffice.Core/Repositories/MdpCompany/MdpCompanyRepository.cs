namespace OutPost.Modules.Backoffice.Core.Repositories.MdpCompany;

public class MdpCompanyRepository : IMdpCompanyRepository
{
    private readonly List<Entities.MdpCompany> _mdpCompanies = new();

    public async Task<IEnumerable<Entities.MdpCompany>> Get()
        => _mdpCompanies;

    public async Task<Entities.MdpCompany?> GetById(Guid id)
        => _mdpCompanies.Find(x => x.Id == id);

    public async Task Create(Entities.MdpCompany mdpCompany)
    {
        _mdpCompanies.Add(mdpCompany);
    }
}
