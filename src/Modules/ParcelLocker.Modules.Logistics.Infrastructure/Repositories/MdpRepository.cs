using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints;
using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;

namespace ParcelLocker.Modules.Logistics.Infrastructure.Repositories;

public class MdpRepository : IMdpRepository
{
    private readonly List<MediativeDeliveryPoint> _mediativeDeliveryPoints = new ();

    public async Task Create(MediativeDeliveryPoint mediativeDeliveryPoint)
    {
        _mediativeDeliveryPoints.Add(mediativeDeliveryPoint);
    }

    public async Task<IEnumerable<MediativeDeliveryPoint>> Get()
        => _mediativeDeliveryPoints;

    public async Task<MediativeDeliveryPoint?> GetById(MediativeDeliveryPointId mdpId)
        => _mediativeDeliveryPoints.FirstOrDefault(x => x.Id.Id == mdpId.Id);
}
