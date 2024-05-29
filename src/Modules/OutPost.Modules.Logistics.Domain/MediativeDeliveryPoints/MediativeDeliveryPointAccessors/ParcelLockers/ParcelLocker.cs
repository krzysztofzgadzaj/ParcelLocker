using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts.ParcelLockers;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Specifications.ParcelLockers;
using OutPost.Modules.Logistics.Domain.Shared;
using OutPost.Shared.Abstractions.Localization;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.ParcelLockers;

public class ParcelLocker : MediativeDeliveryPoint
{
    internal ParcelLocker(ParcelLockerDraft parcelLockerDraft)
    {
        var slotsSizeParameters = parcelLockerDraft
            .Slots
            .Select(x => x.ParcelLockerSlotSizeParameters);
        
        var hasMandatorySlots = new ParcelLockerHasMandatorySlots().Check(slotsSizeParameters);

        if (!hasMandatorySlots)
        {
            throw new CannotCreateParcelLockerWithoutMandatorySlotsException("Parcel locker needs to contain required mandatory slots");
        }

        if (!parcelLockerDraft.MdpCompany.MdpTypeAllowed(MdpType))
        {
            throw new MdpCannotBeCreatedForCompanyException($"Parcel locker is not allowed for company {parcelLockerDraft.MdpCompany.Id}");
        }

        MdpCompany = parcelLockerDraft.MdpCompany;
        Slots = parcelLockerDraft.Slots.Select(x => new ParcelLockerSlot(x)).ToList();
        SerialCode = parcelLockerDraft.SerialCode;
        Address = parcelLockerDraft.Address;
        Id = Guid.NewGuid();
    }
    
    public MdpCompany MdpCompany { get; init; }
    public Address Address { get; init; }
    public ParcelLockerSerialCode SerialCode { get; init; }
    public List<ParcelLockerSlot> Slots { get; init; }
    public MdpStatus Status => MdpStatus.Active;
    public MdpTypes MdpType => MdpTypes.ParcelLocker;

    public override void Deactivate()
    {
        if (Slots.Any(x => x.IsReservedOrOccupied))
        {
            throw new CannotDeactivateMdpWithParcelsOrReservationsException($"Parcel Locker with Id: {Id} cannot be deactivated");
        }

        // TODO - Create MdpDraft
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

    public override void StoreParcel(Guid parcelId)
    {
        var assignedSlot = Slots.FirstOrDefault(x => x.AssignedParcelId == parcelId);

        if (assignedSlot is null)
        {
            throw new ApplicationException();
        }
        
        assignedSlot.StoreParcel();
    }
}
