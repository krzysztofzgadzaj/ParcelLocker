namespace ParcelLocker.Modules.Commission.Application.Clients.BackOfficeClient;

public interface IBackofficeClient
{
    Task<OutpostConfigurationDto> GetOutpostConfiguration();
}