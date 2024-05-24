using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Repositories;
using OutPost.Shared.Abstractions.Queries;

namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Queries.GetAvailableMdpsForParcel;

public class GetAvailableMdpsForParcelQueryHandler : IQueryHandler<GetAvailableMdpsForParcelQuery, IEnumerable<MdpDto>>
{
    private readonly IMdpRepository _mdpRepository;

    public GetAvailableMdpsForParcelQueryHandler(IMdpRepository mdpRepository)
    {
        _mdpRepository = mdpRepository;
    }

    public async Task<IEnumerable<MdpDto>> HandleAsync(GetAvailableMdpsForParcelQuery query)
    {
        var availableMdps = await _mdpRepository.GetAvailableMdpsForParcel(new ParcelParameters(
            query.ParcelLengthInCm,
            query.ParcelWidthInCm,
            query.ParcelHeightInCm,
            query.ParcelWeightInKg));

        var dtos = availableMdps.Select(x => x.Map());

        return dtos;
    }
}
