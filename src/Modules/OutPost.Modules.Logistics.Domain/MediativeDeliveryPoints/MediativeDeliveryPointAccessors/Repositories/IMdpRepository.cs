using OutPost.Modules.Logistics.Domain.Shared;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Repositories;

public interface IMdpRepository
{
    Task Create(MediativeDeliveryPoint mediativeDeliveryPoint);
    Task<IEnumerable<MediativeDeliveryPoint>> Get();
    Task<MediativeDeliveryPoint?> GetById(Guid mdpId);
    Task<IEnumerable<MediativeDeliveryPoint>> GetAvailableMdpsForParcel(ParcelParameters parcelParameters);
}
