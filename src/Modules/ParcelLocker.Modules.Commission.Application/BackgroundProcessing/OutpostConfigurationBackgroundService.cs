using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParcelLocker.Modules.Commission.Application.Clients.BackOfficeClient;

namespace ParcelLocker.Modules.Commission.Application.BackgroundProcessing;

public class OutpostConfigurationBackgroundService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public OutpostConfigurationBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var backofficeClient = scope.ServiceProvider.GetRequiredService<IBackofficeClient>();
        var outpostConfiguration = await backofficeClient.GetOutpostConfiguration();
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
