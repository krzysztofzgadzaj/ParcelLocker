using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;
using OutPost.Shared.Abstractions.Localization;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.ShoppingPoint;

public class ShoppingPoint : MediativeDeliveryPoint
{
    public ShoppingPoint(MdpCompany mdpCompany, Address address, ShoppingPointIdentifier shoppingPointIdentifier, StorageCapacity storageCapacity)
    {
        if (!mdpCompany.MdpTypeAllowed(MdpType))
        {
            throw new MdpCannotBeCreatedForCompanyException("Elo");
        }
        
        MdpCompany = mdpCompany;
        Address = address;
        ShoppingPointIdentifier = shoppingPointIdentifier;
        Status = MdpStatus.Inactive;
        StorageCapacity = storageCapacity;
    }

    public MdpCompany MdpCompany { get; }
    public Address Address { get; }
    public ShoppingPointIdentifier ShoppingPointIdentifier { get; }
    public StorageCapacity StorageCapacity { get; }
    public MdpStatus Status { get; private set; }
    public MdpTypes MdpType => MdpTypes.ShoppingPoint;

    public override bool IsActive()
    {
        throw new NotImplementedException();
    }

    public override void Activate()
    {
        Status = MdpStatus.Active;
    }

    public override void Deactivate()
    {
        throw new NotImplementedException();
    }

    public override bool CanStoreParcel(ParcelParameters parcelParameters)
    {
        throw new NotImplementedException();
    }
}
