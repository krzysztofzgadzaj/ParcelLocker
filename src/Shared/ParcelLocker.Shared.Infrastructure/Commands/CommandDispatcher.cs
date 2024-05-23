using Microsoft.Extensions.DependencyInjection;
using ParcelLocker.Shared.Abstractions.Commands;

namespace ParcelLocker.Shared.Infrastructure.Commands;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        await handler.SendAsync(command);
    }
}
