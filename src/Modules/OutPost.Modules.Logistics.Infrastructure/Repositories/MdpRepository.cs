using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;

namespace OutPost.Modules.Logistics.Infrastructure.Repositories;

public class MdpRepository : IMdpRepository
{
    private readonly List<MediativeDeliveryPoint> _mediativeDeliveryPoints = new();

    public async Task Create(MediativeDeliveryPoint mediativeDeliveryPoint)
    {
        _mediativeDeliveryPoints.Add(mediativeDeliveryPoint);
    }

    public async Task<IEnumerable<MediativeDeliveryPoint>> Get()
        => _mediativeDeliveryPoints;

    public async Task<MediativeDeliveryPoint?> GetById(Guid mdpId)
        => _mediativeDeliveryPoints.FirstOrDefault(x => x.Id == mdpId);
}
