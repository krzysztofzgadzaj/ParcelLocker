namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared;

[Flags]
public enum MdpTypes
{
    None = 0,
    ParcelLocker = 1 << 0,
    ShoppingPoint = 1 << 1,
    All = ParcelLocker | ShoppingPoint
}
