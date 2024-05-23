namespace ParcelLocker.Modules.Backoffice.Core.Repositories.OutpostConfiguration;

public interface IOutpostConfigurationRepository
{
    Task UpdateOutpostMarkup(decimal markup);
    Task<Entities.OutpostConfiguration> GetSingle();
}
