using ParcelLocker.Shared.Abstractions.Queries;

namespace ParcelLocker.Shared.Infrastructure.Queries;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
}
