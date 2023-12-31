using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Storerooms;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities;

public abstract class Storehouse : AggregateRoot
{
    public string IdentificationCode { get; set; }
    // TODO - Change to type that represents coordinates 
    public string Location { get; set; }
    public List<Storeroom> Storerooms { get; set; }
}
