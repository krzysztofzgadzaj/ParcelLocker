using System.Linq.Expressions;
using OutPost.Shared.Abstractions.Kernel.Specification;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Specifications.ParcelLockers;

public class ParcelLockerHasMandatorySlots : Specification<IEnumerable<ParcelLockerSlotSizeParameters>>
{
    protected override Expression<Func<IEnumerable<ParcelLockerSlotSizeParameters>, bool>> AsPredicateExpression()
    {
        return slots 
            => new ParcelLockerHasMandatoryAmountOfSmallSlots()
                .Or(new ParcelLockerHasMandatoryAmountOfMediumSlots())
                .Or(new ParcelLockerHasMandatoryAmountOfLargeSlots())
                .Check(slots);
    }
}
