using ParcelLocker.Shared.Abstractions.Commands;

namespace ParcelLocker.Shared.Infrastructure.Commands;

public interface ICommandDispatcher
{
    Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
}