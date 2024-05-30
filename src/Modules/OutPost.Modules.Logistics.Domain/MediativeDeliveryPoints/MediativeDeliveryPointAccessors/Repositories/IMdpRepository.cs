using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts;
using OutPost.Modules.Logistics.Domain.Shared;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Repositories;

public interface IMdpRepository
{
    Task CreateMdpDraft(MediativeDeliveryPointDraft mediativeDeliveryPointDraft);
    Task ReplaceDraftWithActiveMdp(MediativeDeliveryPointAccessor mediativeDeliveryPointAccessor);
    Task<MediativeDeliveryPointDraft> GetMdpDraft(Guid id);
    Task<IEnumerable<MediativeDeliveryPoint>> GetAvailableMdpsForParcel(ParcelParameters parcelParameters);
}
