using ParcelLocker.Shared.Abstractions.Clients;
using ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry;

namespace ParcelLocker.Shared.Infrastructure.Clients;

public class InMemoryClient : IClient
{
    private readonly IModuleClient _moduleClient;

    public InMemoryClient(IModuleClient moduleClient)
    {
        _moduleClient = moduleClient;
    }

    public async Task<T> SendAsync<T>(string path, object arguments)
        => await _moduleClient.SendAsync<T>(path, arguments);
}
