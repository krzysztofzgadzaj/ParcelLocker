using ParcelLocker.Modules.Commission.Application.Clients.BackOfficeClient;
using ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry;

namespace ParcelLocker.Modules.Commission.Infrastructure.Clients;

public class BackofficeClient : IBackofficeClient
{
    private readonly IModuleClient _moduleClient;

    public BackofficeClient(IModuleClient moduleClient)
    {
        _moduleClient = moduleClient;
    }

    public async Task<OutpostConfigurationDto> GetOutpostConfiguration()
    {
        var outpostConfiguration = await _moduleClient.SendAsync<OutpostConfigurationDto>(
            "/outpost-configuration/markup", 
            null);

        return outpostConfiguration;
    }
}
