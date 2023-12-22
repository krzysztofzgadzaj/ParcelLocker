using ParcelLocker.Shared.Abstractions.Queries;

namespace ParcelLocker.Modules.History.Core.Queries;

public class TempQueryHandler : IQueryHandler<TempQuery, int>
{
    public async Task<int> HandleAsync(TempQuery query)
    {
        return 15;
    }
}
