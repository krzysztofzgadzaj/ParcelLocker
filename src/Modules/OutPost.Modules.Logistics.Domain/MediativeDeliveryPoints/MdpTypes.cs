namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints;

[Flags]
public enum MdpTypes
{
    None = 0,
    ParcelLocker = 1 << 0,
    ShoppingPoint = 1 << 1
}
