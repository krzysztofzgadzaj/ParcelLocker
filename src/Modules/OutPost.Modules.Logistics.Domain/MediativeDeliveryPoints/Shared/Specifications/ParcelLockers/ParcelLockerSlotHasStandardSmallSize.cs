using System.Linq.Expressions;
using OutPost.Shared.Abstractions.Kernel.Specification;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Specifications.ParcelLockers;

public class ParcelLockerSlotHasStandardSmallSize : Specification<ParcelLockerSlotSizeParameters>
{
    protected override Expression<Func<ParcelLockerSlotSizeParameters, bool>> AsPredicateExpression()
    {
        return slot => slot.LengthInCm == 8.0d && slot.WidthInCm == 38.0d && slot.HeightInCm == 64.0d;
    }
}
