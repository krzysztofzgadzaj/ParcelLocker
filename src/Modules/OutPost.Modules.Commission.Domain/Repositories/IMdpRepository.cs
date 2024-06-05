namespace OutPost.Modules.Commission.Domain.Repositories;

public interface IMdpRepository
{
    Task AddAsync(Mdp mdp);
    Task UpdateAsync(Mdp mdp);
    Task<Mdp?> GetByIdAsync(Guid id);
}
