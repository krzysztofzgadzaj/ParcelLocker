using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Delivery;

public abstract class Vehicle : AggregateRoot
{
    public string RegistrationNumber { get; private set; }
    
}
