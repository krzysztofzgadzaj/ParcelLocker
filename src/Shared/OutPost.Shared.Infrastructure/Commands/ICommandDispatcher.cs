using OutPost.Shared.Abstractions.Commands;

namespace OutPost.Shared.Infrastructure.Commands;

public interface ICommandDispatcher
{
    Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
}