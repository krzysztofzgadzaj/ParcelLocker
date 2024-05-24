using System.Linq.Expressions;
using OutPost.Shared.Abstractions.Kernel.Specification;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Specifications.ParcelLockers;

public class ParcelLockerHasMandatoryAmountOfMediumSlots : Specification<IEnumerable<ParcelLockerSlotSizeParameters>>
{
    private const int MandatoryMediumSizeSlotsAmount = 10;
    
    protected override Expression<Func<IEnumerable<ParcelLockerSlotSizeParameters>, bool>> AsPredicateExpression()
    {
        return slots => slots
                            .Count(slot => new ParcelLockerSlotHasStandardMediumSize().Check(slot)) 
                        >= MandatoryMediumSizeSlotsAmount;
    }
}
