namespace OutPost.Modules.Commission.Application.Repositories;

public interface IOutpostConfigurationRepository
{
    Task<decimal?> GetOutpostMarkup();
    Task UpdateOutpostMarkup(double markup);
}

public class OuRepo : IOutpostConfigurationRepository
{
    public Task<decimal?> GetOutpostMarkup()
    {
        throw new NotImplementedException();
    }

    public Task UpdateOutpostMarkup(double markup)
    {
        throw new NotImplementedException();
    }
}