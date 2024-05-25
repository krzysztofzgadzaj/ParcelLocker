﻿using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;
using OutPost.Modules.Logistics.Domain.Shared;
using OutPost.Shared.Abstractions.Localization;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.ShoppingPoints;

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

    public override void Deactivate()
    {
        throw new NotImplementedException();
    }

    public override bool CanStoreParcel(ParcelParameters parcelParameters)
    {
        throw new NotImplementedException();
    }

    public override void ReserveSlotForParcel(Parcel parcel)
    {
        throw new NotImplementedException();
    }

    public override void StoreParcel(Guid parcelId)
    {
        throw new NotImplementedException();
    }
}
