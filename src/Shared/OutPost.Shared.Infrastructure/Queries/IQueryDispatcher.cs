using OutPost.Shared.Abstractions.Queries;

namespace OutPost.Shared.Infrastructure.Queries;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
}
