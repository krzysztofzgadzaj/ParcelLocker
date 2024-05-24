namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts.Repositories;

public interface IMdpDraftRepository
{
    Task Create(MediativeDeliveryPointDraft mediativeDeliveryPointDraft);
    Task<IEnumerable<MediativeDeliveryPointDraft>> Get();
    Task<MediativeDeliveryPointDraft?> GetById(Guid mdpId);
}
