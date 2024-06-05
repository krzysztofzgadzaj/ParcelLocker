namespace OutPost.Modules.Commission.Application.Repositories;

public interface IOutpostConfigurationRepository
{
    Task<decimal?> GetOutpostMarkup();
    Task UpdateOutpostMarkup(double markup);
}
