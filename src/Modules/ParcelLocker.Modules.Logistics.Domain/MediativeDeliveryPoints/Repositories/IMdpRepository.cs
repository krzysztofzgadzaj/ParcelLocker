namespace ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;

public interface IMdpRepository
{
    Task Create(MediativeDeliveryPoint mediativeDeliveryPoint);
    Task<IEnumerable<MediativeDeliveryPoint>> Get();
    Task<MediativeDeliveryPoint?> GetById(MediativeDeliveryPointId mdpId);
}
