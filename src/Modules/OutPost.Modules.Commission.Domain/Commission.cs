using OutPost.Modules.Commission.Domain.DeliveryMethods;
using OutPost.Modules.Commission.Domain.Events;
using OutPost.Modules.Commission.Domain.Strategies;
using OutPost.Shared.Abstractions.Kernel.Types;

namespace OutPost.Modules.Commission.Domain;

public class Commission : AggregateRoot
{
    private Commission(ParcelParameters parcelParameters, 
        DeliveryMethod parcelStartingPoint, 
        DeliveryMethod parcelDeliveryPoint, 
        decimal outpostMarkup)
    {
        Id = Guid.NewGuid();
        OutpostMarkup = outpostMarkup;
        ParcelParameters = parcelParameters;
        ParcelStartingPoint = parcelStartingPoint;
        ParcelDeliveryPoint = parcelDeliveryPoint;
        Status = CommissionStatus.UnderProcessing;
    }

    public ParcelParameters ParcelParameters { get; }
    public DeliveryMethod ParcelStartingPoint { get; }
    public DeliveryMethod ParcelDeliveryPoint { get; }
    public decimal OutpostMarkup { get; }
    public CommissionStatus Status { get; private set; }
    public bool IsValidated { get; private set; }
    public bool IsPaid { get; private set; }

    public void MarkAsValidated()
    {
        if (Status != CommissionStatus.UnderProcessing)
        {
            throw new ApplicationException();
        }
        
        IsValidated = true;
    }

    public void MarkAsPaid()
    {
        if (Status != CommissionStatus.UnderProcessing)
        {
            throw new ApplicationException();
        }
        
        IsPaid = true;
    }

    public decimal TotalCost =>
        new CalculateDeliveryCostStrategy()
            .CalculateDeliveryCost(
                OutpostMarkup, 
                ParcelStartingPoint, 
                ParcelDeliveryPoint);

    public static Commission CreateCommission(ParcelParameters parcelParameters,
        DeliveryMethod parcelStartingPoint,
        DeliveryMethod parcelDeliveryPoint,
        decimal outpostMarkup)
    {
        var commission = new Commission(parcelParameters,
            parcelStartingPoint,
            parcelDeliveryPoint,
            outpostMarkup);
        
        commission.AddEvent(new CommissionCreatedDomainEvent(commission.Id));
        return commission;
    }
}
