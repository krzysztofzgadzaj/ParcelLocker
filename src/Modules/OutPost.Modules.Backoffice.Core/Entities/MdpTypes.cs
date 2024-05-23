namespace OutPost.Modules.Backoffice.Core.Entities;

[Flags]
public enum MdpTypes
{
    ParcelLocker = 1 << 0,
    ShoppingPoint = 1 << 1
}
