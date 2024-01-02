using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments;
using ParcelLocker.Modules.Logistics.Domain.Storage.Specifications;
using ParcelLocker.Shared.Abstractions.Specification;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Factories;

public class StoringSpecificationFactory
{
    //ublic Specification<MaterializedContainer> GetConditions(Shipment shipment)
    //   => shipment.ShipmentType switch
    //   {
    //       ShipmentType.FreshFoodShipment => new ContainerCanStoreVegetables(),
    //       ShipmentType.StandardShipment => new ContainerCanStoreVegetables().Or(new ContainerCanStoreVegetables()),
    //       _ => throw new ArgumentOutOfRangeException()
    //   };
}
