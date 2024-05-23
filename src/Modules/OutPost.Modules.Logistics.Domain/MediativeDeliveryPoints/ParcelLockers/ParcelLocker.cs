using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;
using OutPost.Shared.Abstractions.Localization;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.ParcelLockers;

public class ParcelLocker : MediativeDeliveryPoint
{
    public ParcelLocker(IEnumerable<ParcelLockerSlot> slots, ParcelLockerSerialCode serialCode, Address address, MdpCompany mdpCompany)
    {
        var minimumSmallSlotsAmountMatches = slots.Count(x => x.HasStandardSmallDimensions) >= 2;
        var minimumMediumSlotsAmountMatches = slots.Count(x => x.HasStandardMediumDimensions) >= 1;
        var minimumBigSlotsAmountMatches = slots.Count(x => x.HasStandardBigDimensions) >= 1;

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
        if (Slots.Any(x => x.IsReservedOrOccupied))
        {
            throw new CannotDeactivateMdpWithParcelsOrReservationsException($"Parcel with Id: {Id} cannot be deactivated");
        }

        Status = MdpStatus.Inactive;
    }

    public override bool CanStoreParcel(ParcelParameters parcelParameters)
    {
        throw new NotImplementedException();
    }
}
