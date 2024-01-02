using System.Linq.Expressions;
using ParcelLocker.Modules.Logistics.Domain.Storage.Entities.Materialization;
using ParcelLocker.Shared.Abstractions.Specification;

namespace ParcelLocker.Modules.Logistics.Domain.Storage.Specifications;

public class ContainerCanStoreVegetables : Specification<MaterializedContainer>
{
    protected override Expression<Func<MaterializedContainer, bool>> AsPredicateExpression()
    {
        return container => HasNoFrostSystem(container);
    }

    private bool HasNoFrostSystem(MaterializedContainer container)
        => container.HasNoFrostSystem;
}
