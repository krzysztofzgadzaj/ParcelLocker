using Microsoft.EntityFrameworkCore;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Repositories;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts;
using OutPost.Modules.Logistics.Domain.Shared;
using OutPost.Modules.Logistics.Infrastructure.Persistence.WriteModels;
using OutPost.Shared.Abstractions.TextSerializer;

namespace OutPost.Modules.Logistics.Infrastructure.Persistence.Repositories;

public class MdpRepository : IMdpRepository
{
    private readonly LogisticsContext _logisticsContext;
    private readonly ITextSerializer _textSerializer;

    public MdpRepository(LogisticsContext logisticsContext, ITextSerializer textSerializer)
    {
        _logisticsContext = logisticsContext;
        _textSerializer = textSerializer;
    }

    public async Task CreateMdpDraft(MediativeDeliveryPointDraft mediativeDeliveryPointDraft)
    {
        var mdpWriteModel = new MediativeDeliveryPointWriteModel()
        {
            MdpId = mediativeDeliveryPointDraft.Id,
            Type = MediativeDeliveryPointWriteModel.DraftType,
            Payload = _textSerializer.Serialize(mediativeDeliveryPointDraft)
        };

        await _logisticsContext.AddAsync(mdpWriteModel);
        await _logisticsContext.SaveChangesAsync();
    }

    public async Task ReplaceDraftWithActiveMdp(MediativeDeliveryPointAccessor mediativeDeliveryPointAccessor)
    {
        var mdpDraft = await _logisticsContext
            .MediativeDeliveryPointsPoints
            .FirstOrDefaultAsync(x
                => x.MdpId == mediativeDeliveryPointAccessor.Id
                   && x.Type == MediativeDeliveryPointWriteModel.DraftType);

        if (mdpDraft is null)
        {
            throw new ArgumentException();
        }

        mdpDraft.Type = MediativeDeliveryPointWriteModel.AccessorType;
        mdpDraft.Payload = _textSerializer.Serialize(mediativeDeliveryPointAccessor);
        await _logisticsContext.SaveChangesAsync();
    }

    public async Task<MediativeDeliveryPointDraft> GetMdpDraft(Guid id)
    {
        var mdp = await _logisticsContext
            .MediativeDeliveryPointsPoints
            .FirstOrDefaultAsync(x => x.MdpId == id);

        if (mdp is null)
        {
            throw new ArgumentException();
        }

        var mdpDraft = _textSerializer.Deserialize<MediativeDeliveryPointDraft>(mdp.Payload);
        return mdpDraft;
    }

    public Task<IEnumerable<MediativeDeliveryPoint>> GetAvailableMdpsForParcel(ParcelParameters parcelParameters)
    {
        throw new NotImplementedException();
    }
}
