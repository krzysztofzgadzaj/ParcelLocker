namespace ParcelLocker.Modules.Commission.Domain;

public class MdpCompany
{
    public MdpCompany(MdpCompanyId id, int markup)
    {
        Id = id;
        Markup = markup;
        MediativeDeliveryPoints = new List<MediativeDeliveryPoint>();
    }

    public MdpCompanyId Id { get; }
    public int Markup { get; private set; }
    public IList<MediativeDeliveryPoint> MediativeDeliveryPoints { get; private set; }

    public void UpdateMarkup(int markup)
    {
        Markup = markup;
    }

    public void AssignMediativeDeliveryPoint(MediativeDeliveryPoint mediativeDeliveryPoint)
    {
        if (mediativeDeliveryPoint.MdpCompanyId != Id)
        {
            throw new ArgumentException();
        }
        
        MediativeDeliveryPoints.Add(mediativeDeliveryPoint);
    }
}
