namespace OutPost.Modules.Logistics.Infrastructure.Persistence.WriteModels;

public class MediativeDeliveryPointWriteModel
{
    public const string DraftType = "MediativeDeliveryPointDraft";
    public const string AccessorType = "MediativeDeliveryPointAccessor";
    
    public Guid MdpId { get; set; }
    public string Type { get; set; }
    public string Payload { get; set; }
}
