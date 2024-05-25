using OutPost.Modules.Logistics.Domain.Shared;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.SlotUnlockMethods;

public class ParcelAccessRegistry
{
    private List<CodeAccessRegistryEntry> CodeAccessRegistryEntries { get; init; } = new();

    public void CreateCodeAccess(string phoneNumber, Deadline deadline, Guid parcelId)
    {
        CodeAccessRegistryEntries.Add(new CodeAccessRegistryEntry(parcelId, phoneNumber, deadline));
    }

    public Guid? VerifyCodeAccess(string phoneNumber, int code)
    {
        var dupa = CodeAccessRegistryEntries.FirstOrDefault(x => x.ValidateCode(phoneNumber, code));

        if (dupa is null)
        {
            return null;
        }

        return dupa.ParcelId;
    }
}
