using ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;
using ParcelLocker.Shared.Abstractions.Localization;

namespace ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.ParcelLocker;

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
        Id = new MediativeDeliveryPointId(Guid.NewGuid());
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
}
