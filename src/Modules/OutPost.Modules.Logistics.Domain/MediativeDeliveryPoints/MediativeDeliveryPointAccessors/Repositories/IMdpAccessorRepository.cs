using OutPost.Shared.Abstractions.Kernel.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Repositories;

public interface IMdpAccessorRepository
{
    Task<MediativeDeliveryPointAccessor> GetById(AggregateId id);
}