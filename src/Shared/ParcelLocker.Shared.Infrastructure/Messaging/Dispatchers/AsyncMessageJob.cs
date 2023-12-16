using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ParcelLocker.Shared.Infrastructure.Modules.ModuleRegistry;

namespace ParcelLocker.Shared.Infrastructure.Messaging.Dispatchers;

public class AsyncMessageJob : BackgroundService
{
    private readonly IMessageChannel _messageChannel;
    private readonly IModuleClient _moduleClient;
    private readonly ILogger<AsyncMessageJob> _logger;
    
    public AsyncMessageJob(IMessageChannel messageChannel, IModuleClient moduleClient, ILogger<AsyncMessageJob> logger)
    {
        _messageChannel = messageChannel;
        _moduleClient = moduleClient;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Background message proceeding started");
        
        await foreach (var message in _messageChannel.Reader.ReadAllAsync(stoppingToken))
        {
            try
            {
                await _moduleClient.PublishAsync(message);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
        }
        
        _logger.LogInformation("Background message proceeding completed");
    }
}
