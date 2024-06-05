namespace OutPost.Modules.Commission.Domain.Repositories;

public interface ICommissionRepository
{
    Task<Commission> GetByIdAsync(Guid id);
    Task CreateAsync(Commission commission);
    Task UpdateAsync(Commission commission);
}
