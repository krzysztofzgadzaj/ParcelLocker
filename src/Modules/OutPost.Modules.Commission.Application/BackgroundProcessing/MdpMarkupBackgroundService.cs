using Microsoft.Extensions.Hosting;
using OutPost.Modules.Commission.Domain.Repositories;

namespace OutPost.Modules.Commission.Application.BackgroundProcessing;

public class MdpMarkupBackgroundService : IHostedService
{
    private readonly IMdpRepository _mdpRepository;

    public MdpMarkupBackgroundService(IMdpRepository mdpRepository)
    {
        _mdpRepository = mdpRepository;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
