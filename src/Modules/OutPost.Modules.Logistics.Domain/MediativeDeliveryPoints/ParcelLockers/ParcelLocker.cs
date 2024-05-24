using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;
using OutPost.Shared.Abstractions.Localization;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.ParcelLockers;

public class ParcelLocker : MediativeDeliveryPoint
{
    public ParcelLocker(IEnumerable<ParcelLockerSlot> slots, ParcelLockerSerialCode serialCode, Address address, MdpCompany mdpCompany)
    {
        var minimumSmallSlotsAmountMatches = slots.Count(x => x.HasStandardSmallDimensions) >= 20;
        var minimumMediumSlotsAmountMatches = slots.Count(x => x.HasStandardMediumDimensions) >= 10;
        var minimumBigSlotsAmountMatches = slots.Count(x => x.HasStandardBigDimensions) >= 5;

        if (!(minimumSmallSlotsAmountMatches && minimumMediumSlotsAmountMatches && minimumBigSlotsAmountMatches))
        {
            throw new CannotCreateParcelLockerWithoutMandatorySlotsException(
                "Parcel locker needs to contain required mandatory slots");
        }

        if (!mdpCompany.MdpTypeAllowed(MdpType))
        {
            throw new MdpCannotBeCreatedForCompanyException("Elo");
        }

        MdpCompany = mdpCompany;
        Slots = slots;
        SerialCode = serialCode;
        Address = address;
        Status = MdpStatus.Inactive;
        Id = Guid.NewGuid();
    }
    
    public MdpCompany MdpCompany { get; init; }
    public Address Address { get; init; }
    public ParcelLockerSerialCode SerialCode { get; init; }
    public IEnumerable<ParcelLockerSlot> Slots { get; init; }
    public MdpStatus Status { get; private set; }
    public MdpTypes MdpType => MdpTypes.ParcelLocker;

    public override void Activate()
    {
        Status = MdpStatus.Active;
    }

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
