using System.Linq.Expressions;
using OutPost.Shared.Abstractions.Kernel.Specification;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Specifications.ParcelLockers;

public class ParcelLockerHasMandatoryAmountOfLargeSlots : Specification<IEnumerable<ParcelLockerSlotSizeParameters>>
{
    private const int MandatoryLargeSizeSlotsAmount = 5;
    
    protected override Expression<Func<IEnumerable<ParcelLockerSlotSizeParameters>, bool>> AsPredicateExpression()
    {
        return slots => slots
                            .Count(slot => new ParcelLockerSlotHasStandardLargeSize().Check(slot)) 
                        >= MandatoryLargeSizeSlotsAmount;
    }
}
