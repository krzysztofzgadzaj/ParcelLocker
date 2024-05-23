namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;

public interface IMdpAvaiability
{
    bool IsActive();
    void Activate();
    void Deactivate();
}
