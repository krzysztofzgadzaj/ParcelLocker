namespace OutPost.Modules.Commission.Domain.Repositories;

public interface IMdpRepository
{
    Task AddAsync(Mdp mdp);
    Task UpdateAsync(Mdp mdp);
    Task<Mdp?> GetByIdAsync(Guid id);
}

public class MdpRepo : IMdpRepository
{
    public Task AddAsync(Mdp mdp)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Mdp mdp)
    {
        throw new NotImplementedException();
    }

    public Task<Mdp?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}