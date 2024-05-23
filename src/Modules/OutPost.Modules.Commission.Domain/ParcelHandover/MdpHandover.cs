namespace OutPost.Modules.Commission.Domain.ParcelHandover;

public class MdpHandover : Handover
{
    public MdpHandover(MediativeDeliveryPoint mediativeDeliveryPoint)
    {
        MediativeDeliveryPoint = mediativeDeliveryPoint;
    }

    public MediativeDeliveryPoint MediativeDeliveryPoint { get; }
    public ParcelHandoverType ParcelHandoverType => ParcelHandoverType.Mdp;
}
