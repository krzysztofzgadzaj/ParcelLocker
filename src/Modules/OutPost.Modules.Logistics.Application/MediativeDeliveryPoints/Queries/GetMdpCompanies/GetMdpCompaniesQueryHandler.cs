using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;
using OutPost.Shared.Abstractions.Queries;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Queries.GetMdpCompanies;

public class GetMdpCompaniesQueryHandler : IQueryHandler<GetMdpCompaniesQuery, IEnumerable<MdpCompanyDto>>
{
    private readonly IMdpCompanyRepository _mdpCompanyRepository;

    public GetMdpCompaniesQueryHandler(IMdpCompanyRepository mdpCompanyRepository)
    {
        _mdpCompanyRepository = mdpCompanyRepository;
    }

    public async Task<IEnumerable<MdpCompanyDto>> HandleAsync(GetMdpCompaniesQuery query)
    {
        var mdpCompanies = await _mdpCompanyRepository.GetMdpCompanies();
        var mdpCompaniesDto = mdpCompanies.Select(x => new MdpCompanyDto(x));

        return mdpCompaniesDto;
    }
}
