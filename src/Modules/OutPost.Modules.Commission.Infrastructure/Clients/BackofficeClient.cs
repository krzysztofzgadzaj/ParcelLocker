using OutPost.Modules.Commission.Application.Clients.BackOfficeClient;
using OutPost.Shared.Infrastructure.Modules.ModuleRegistry;

namespace OutPost.Modules.Commission.Infrastructure.Clients;

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
