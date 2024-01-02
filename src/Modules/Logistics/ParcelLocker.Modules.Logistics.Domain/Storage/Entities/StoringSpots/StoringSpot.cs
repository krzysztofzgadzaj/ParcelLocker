using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Shipments;
using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Storerooms;
using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots.Fresh;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Entities.StoringSpots;

public class StoringSpot: AggregateRoot
{
    public AggregateId StoreroomId { get; set; }
    public Storeroom Storeroom { get; set; }
    public StoringMethodType StoringMethodType { get; set; }
    public StoringSpotType StoringSpotType { get; set; }
    public int? ShelvesNumber { get; set; }
    public ShipmentType AllowedShipmentType { get; set; }
    public IList<Shelve> Shelves = new List<Shelve>();
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public double Volume => Width * Height * Length;
    public double MaxLoad { get; set; }
    public double Temperature { get; set; }
    public double AirHumidity { get; set; }
    public FoodControlSystems FoodControlSystems { get; set; }

    public List<Shipment> Shipments { get; set; } = new();

    public StoringSpot(int shelvesNumber)
    {
        if (shelvesNumber > 0)
        {
            ShelvesNumber = shelvesNumber;
        }
        
        for (var i = 0; i < ShelvesNumber; i++)
        {
            Shelves.Add(new Shelve
            {
                Length = Length,
                Width = Width,
                MaxLoad = MaxLoad / ShelvesNumber.Value
            });
        }
    }

    public bool HasPlaceForShipment(Shipment shipment)
    {
        if (shipment.ShipmentType != AllowedShipmentType)
        {
            throw new ArgumentException("Wrong shipment type");
        }

        if (shipment.ShipmentType is ShipmentType.DiaryFoodShipment or ShipmentType.VegetablesShipment or ShipmentType.FruitsShipment)
        {
            if (!shipment.TemperatureInRange(Temperature) || !shipment.HumidityInRange(AirHumidity))
            {
                return false;
            }
        }
        
        if (shipment.ShipmentType is ShipmentType.VegetablesShipment or ShipmentType.FruitsShipment)
        {
            if ((FoodControlSystems & FoodControlSystems.NoFrost) == FoodControlSystems.None)
            {
                return false;
            }
        }
        
        if (StoringMethodType == StoringMethodType.OpenStorage)
        {
            // TODO - some 3D algorithm
            if (GetFreeVolume() - shipment.Volume < 0
                || GetShipmentsWeight() + shipment.Weight > MaxLoad)
            {
                return false;
            }
            
            if (shipment.ShipmentType == ShipmentType.StandardShipment)
            {
                if (shipment.IsBreakable)
                {
                    return false;
                }
            }
        }
        
        if (StoringMethodType == StoringMethodType.ShelfStorage)
        {
            if (!Shelves.Any(x => x.HasPlace(new ShelveObject(shipment.Width, shipment.Length, shipment.Weight))))
            {
                return false;
            }
            
            if (shipment.ShipmentType == ShipmentType.StandardShipment)
            {
                if (shipment.IsBreakable)
                {
                    if (Shelves.FirstOrDefault()
                            ?.HasPlace(new ShelveObject(shipment.Width, shipment.Length, shipment.Weight)) ?? false)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }
    
    public void AddShipment(Shipment shipment)
    {
        if (shipment.ShipmentType != AllowedShipmentType)
        {
            throw new ArgumentException("Wrong shipment type");
        }

        if (!HasPlaceForShipment(shipment))
        {
            throw new ApplicationException("No place for shipment");
        }
        
        // TODO - Create iterators for 2D and 3D (I think)
        Shipments.Add(shipment);

        if (AllowedShipmentType == ShipmentType.DiaryFoodShipment)
        {
            Shipments = Shipments.OrderBy(x => x.ExpirationDate).ToList();
        }
    }

    public void AddShipments(IEnumerable<Shipment> shipments)
    {
        foreach (var shipment in shipments)
        {
            AddShipment(shipment);
        }
    }

    public void RemoveShipment(Shipment shipment)
    {
        Shipments.Remove(shipment);
    }

    public void RemoveShipments(IEnumerable<Shipment> shipments)
    {
        foreach (var shipment in shipments)
        {
            RemoveShipment(shipment);
        }
    }

    private double GetFreeVolume()
        => Volume - Shipments.Sum(x => x.Volume);

    private double GetShipmentsWeight()
        => Shipments.Max(x => x.Weight);
}

public class Shelve
{
    public double Width { get; set; }
    public double Length { get; set; }
    public double MaxLoad { get; set; }
    public IList<ShelveObject> ShelveObjects { get; set; }

    public void AddShipment(ShelveObject shipment)
    {
        // TODO - Some 2D placing packages algorithm
        ShelveObjects.Add(shipment);
    }

    public bool HasPlace(ShelveObject shelveObject)
    {
        // TODO - Some 2D algorithm
        return false;
    }
}

public class ShelveObject
{
    public ShelveObject(double width, double length, double weight)
    {
        Width = width;
        Length = length;
        Weight = weight;
    }

    public double Width { get; set; }
    public double Length { get; set; }
    public double Weight { get; set; }
}
