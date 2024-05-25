using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.ParcelLockers;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;
using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Specifications.ParcelLockers;
using OutPost.Shared.Abstractions.Localization;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointDrafts.ParcelLockers;

public class ParcelLockerDraft : MediativeDeliveryPointDraft
{
    public ParcelLockerDraft(IEnumerable<DraftParcelLockerSlot> slots, ParcelLockerSerialCode serialCode, Address address, MdpCompany mdpCompany)
    {
        var slotsSizeParameters = slots.Select(x => x.ParcelLockerSlotSizeParameters);
        var hasMandatorySlots = new ParcelLockerHasMandatorySlots().Check(slotsSizeParameters);

        if (!hasMandatorySlots)
        {
            throw new CannotCreateParcelLockerWithoutMandatorySlotsException("Parcel locker needs to contain required mandatory slots");
        }

        if (!mdpCompany.MdpTypeAllowed(MdpType))
        {
            throw new MdpCannotBeCreatedForCompanyException("Elo");
        }

        MdpCompany = mdpCompany;
        Slots = slots;
        SerialCode = serialCode;
        Address = address;
        Id = Guid.NewGuid();
    }
    
    public MdpCompany MdpCompany { get; init; }
    public Address Address { get; init; }
    public ParcelLockerSerialCode SerialCode { get; init; }
    public IEnumerable<DraftParcelLockerSlot> Slots { get; init; }
    public MdpStatus Status => MdpStatus.Inactive;
    public MdpTypes MdpType => MdpTypes.ParcelLocker;

    public override MediativeDeliveryPointAccessor Activate()
    {
        return new MediativeDeliveryPointAccessor(new ParcelLocker(this), Id);
    }
}
