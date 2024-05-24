using System.Linq.Expressions;
using OutPost.Shared.Abstractions.Kernel.Specification;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Specifications.ParcelLockers;

public class ParcelLockerSlotHasStandardLargeSize : Specification<ParcelLockerSlotSizeParameters>
{
    protected override Expression<Func<ParcelLockerSlotSizeParameters, bool>> AsPredicateExpression()
    {
        return slot => slot.LengthInCm == 41.0d && slot.WidthInCm == 28.0d && slot.HeightInCm == 64.0d;
    }
}
