using System.Linq.Expressions;
using OutPost.Shared.Abstractions.Kernel.Specification;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Specifications.ParcelLockers;

public class ParcelLockerHasMandatoryAmountOfSmallSlots : Specification<IEnumerable<ParcelLockerSlotSizeParameters>>
{
    private const int MandatorySmallSizeSlotsAmount = 20;
    
    protected override Expression<Func<IEnumerable<ParcelLockerSlotSizeParameters>, bool>> AsPredicateExpression()
    {
        return slots => slots
                            .Count(slot => new ParcelLockerSlotHasStandardSmallSize().Check(slot)) 
                        >= MandatorySmallSizeSlotsAmount;
    }
}
