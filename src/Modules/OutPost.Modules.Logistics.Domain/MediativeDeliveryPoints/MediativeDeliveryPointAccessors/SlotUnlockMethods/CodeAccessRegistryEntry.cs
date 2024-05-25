using OutPost.Modules.Logistics.Domain.Shared;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.SlotUnlockMethods;

public class CodeAccessRegistryEntry
{
    public CodeAccessRegistryEntry(Guid parcelId, string phoneNumber, Deadline deadline)
    {
        UnlockMethod = new CodeUnlockMethod(phoneNumber);
        ParcelId = parcelId;
        Deadline = deadline;
    }

    public CodeUnlockMethod UnlockMethod { get; init; }
    public Guid ParcelId { get; init; }
    public Deadline Deadline { get; init; }

    public bool ValidateCode(string phoneNumber, int code)
    {
        return UnlockMethod.ValidateCombination(phoneNumber, code);
    }
}
