using OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.SlotUnlockMethods;
using OutPost.Modules.Logistics.Domain.Shared;
using OutPost.Shared.Abstractions.Kernel.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors;

public class MediativeDeliveryPointAccessor : AggregateRoot
{
    internal MediativeDeliveryPointAccessor(MediativeDeliveryPoint mediativeDeliveryPoint, AggregateId aggregateId)
    {
        MediativeDeliveryPoint = mediativeDeliveryPoint;
        Id = aggregateId;
    }

    public MediativeDeliveryPoint MediativeDeliveryPoint { get; init; }
    public ParcelAccessRegistry ParcelAccessRegistry { get; init; } = new();

    public void ReserveStorageWithPhoneNumberSafeCodeAccess(Parcel parcel, string phoneNumber, Deadline reservationDeadline)
    {
        MediativeDeliveryPoint.ReserveSlotForParcel(parcel);
        ParcelAccessRegistry.CreateCodeAccess(phoneNumber, reservationDeadline, parcel.Id);
    }

    public void StoreParcelWithPhoneNumberSafeCodeAccess(int code, string phoneNumber)
    {
        var parcelId = ParcelAccessRegistry.InvalidateCode(phoneNumber, code);

        if (parcelId is null)
        {
            throw new ApplicationException();
        }
        
        MediativeDeliveryPoint.StoreParcel(parcelId.Value);
    }
}
