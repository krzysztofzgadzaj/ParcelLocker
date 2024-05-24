using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts.ParcelLockers;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Specifications.ParcelLockers;
using OutPost.Shared.Abstractions.Localization;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.ParcelLockers;

public class ParcelLocker : MediativeDeliveryPoint
{
    internal ParcelLocker(ParcelLockerDraft parcelLockerDraft)
    {
        var slotsSizeParameters = parcelLockerDraft.Slots.Select(x => x.ParcelLockerSlotSizeParameters);
        var hasMandatorySlots = new ParcelLockerHasMandatorySlots().Check(slotsSizeParameters);

        if (!hasMandatorySlots)
        {
            throw new CannotCreateParcelLockerWithoutMandatorySlotsException("Parcel locker needs to contain required mandatory slots");
        }

        if (!parcelLockerDraft.MdpCompany.MdpTypeAllowed(MdpType))
        {
            throw new MdpCannotBeCreatedForCompanyException("Elo");
        }

        MdpCompany = parcelLockerDraft.MdpCompany;
        
        Slots = parcelLockerDraft.Slots.Select(x => new ParcelLockerSlot(x));
        SerialCode = parcelLockerDraft.SerialCode;
        Address = parcelLockerDraft.Address;
        Id = parcelLockerDraft.Id;
    }
    
    public MdpCompany MdpCompany { get; init; }
    public Address Address { get; init; }
    public ParcelLockerSerialCode SerialCode { get; init; }
    public IEnumerable<ParcelLockerSlot> Slots { get; init; }
    public MdpStatus Status { get; private set; }
    public MdpTypes MdpType => MdpTypes.ParcelLocker;

    public override void Deactivate()
    {
        if (Slots.Any(x => x.IsReservedOrOccupied))
        {
            throw new CannotDeactivateMdpWithParcelsOrReservationsException($"Parcel with Id: {Id} cannot be deactivated");
        }

        Status = MdpStatus.Inactive;
    }

    public override bool CanStoreParcel(ParcelParameters parcelParameters)
        => Status == MdpStatus.Active 
           && Slots.Any(x => x.CanStoreParcel(parcelParameters));

    public override void ReserveSlotForParcel(Parcel parcel)
    {
        if (!CanStoreParcel(parcel.ParcelParameters))
        {
            throw new ApplicationException();
        }

        var availableSlot = Slots.First(x => x.CanStoreParcel(parcel.ParcelParameters));
        availableSlot.ReserveSlot(parcel);
    }

    public override void StoreParcel(Parcel parcel)
    {
        var assignedSlot = Slots.FirstOrDefault(x => x.AssignedParcelId == parcel.Id);

        if (assignedSlot is null)
        {
            throw new ApplicationException();
        }
        
        assignedSlot.StoreParcel(parcel);
    }
}
