namespace OutPost.Modules.Commission.Domain.Repositories;

public interface ICommissionRepository
{
    Task<Commission> GetByIdAsync(Guid id);
    Task CreateAsync(Commission commission);
    Task UpdateAsync(Commission commission);
}

public class ComRepo : ICommissionRepository
{
    public Task<Commission> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(Commission commission)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Commission commission)
    {
        throw new NotImplementedException();
    }
}