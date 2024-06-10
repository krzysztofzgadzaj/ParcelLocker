using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OutPost.Modules.Commission.Application.Clients.BackOfficeClient;
using OutPost.Modules.Commission.Application.Repositories;

namespace OutPost.Modules.Commission.Application.BackgroundProcessing.Jobs;

public class OutpostConfigurationBackgroundService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IOutpostConfigurationRepository _outpostConfigurationRepository;

    public OutpostConfigurationBackgroundService(IServiceProvider serviceProvider,
        IOutpostConfigurationRepository outpostConfigurationRepository)
    {
        _serviceProvider = serviceProvider;
        _outpostConfigurationRepository = outpostConfigurationRepository;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var backofficeClient = scope.ServiceProvider.GetRequiredService<IBackofficeClient>();

        try
        {
            var outpostConfiguration = await backofficeClient.GetOutpostConfiguration();
            await _outpostConfigurationRepository.UpdateOutpostMarkup((double)outpostConfiguration.Markup);
        }
        catch (Exception)
        {
            var currentOutpostMarkup = await _outpostConfigurationRepository.GetOutpostMarkup();

            // TODO - throw custom exception and add this one as inner exception (I guess)
            if (currentOutpostMarkup == default)
            {
                throw;
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
