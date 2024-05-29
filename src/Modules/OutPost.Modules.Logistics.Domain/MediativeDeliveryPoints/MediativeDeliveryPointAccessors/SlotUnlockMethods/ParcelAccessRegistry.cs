using OutPost.Modules.Logistics.Domain.Shared;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.SlotUnlockMethods;

public class ParcelAccessRegistry
{
    private readonly List<CodeAccessRegistryEntry> _codeAccessRegistryEntries = new();

    public void CreateCodeAccess(string phoneNumber, Deadline deadline, Guid parcelId)
    {
        _codeAccessRegistryEntries.Add(new CodeAccessRegistryEntry(parcelId, phoneNumber, deadline));
    }
    
    public List<CodeAccessRegistryEntry> CodeAccessRegistryEntries => _codeAccessRegistryEntries;

    public Guid? InvalidateCode(string phoneNumber, int code)
    {
        var dupa = _codeAccessRegistryEntries.FirstOrDefault(x => x.ValidateCode(phoneNumber, code));

        if (dupa is null)
        {
            return null;
        }

        var dupaId = dupa.ParcelId;
        _codeAccessRegistryEntries.Remove(dupa);

        return dupaId;
    }
}
