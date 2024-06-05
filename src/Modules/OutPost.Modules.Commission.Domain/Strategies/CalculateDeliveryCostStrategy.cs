using OutPost.Modules.Commission.Domain.DeliveryMethods;

namespace OutPost.Modules.Commission.Domain.Strategies;

public class CalculateDeliveryCostStrategy
{
    private const decimal BaseCost = 10;
    private const decimal StandardDirectDeliveryMarkup = 25;

    public decimal CalculateDeliveryCost(decimal outpostMarkup, DeliveryMethod startMethod, DeliveryMethod endMethod)
    {
        var costWithOutpostMarkup = BaseCost + BaseCost * outpostMarkup / 100;

        switch (startMethod)
        {
            case DirectDeliveryMethod:
                costWithOutpostMarkup += costWithOutpostMarkup * StandardDirectDeliveryMarkup / 100;
                break;
            case MdpDeliveryMethod method:
                costWithOutpostMarkup += costWithOutpostMarkup * method.Mdp.Markup;
                break;
        }
        
        switch (endMethod)
        {
            case DirectDeliveryMethod:
                costWithOutpostMarkup += costWithOutpostMarkup * StandardDirectDeliveryMarkup / 100;
                break;
            case MdpDeliveryMethod method:
                costWithOutpostMarkup += costWithOutpostMarkup * method.Mdp.Markup;
                break;
        }

        return costWithOutpostMarkup;
    }
}
