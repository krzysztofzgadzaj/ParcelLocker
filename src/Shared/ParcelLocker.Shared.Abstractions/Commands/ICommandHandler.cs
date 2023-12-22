namespace ParcelLocker.Shared.Abstractions.Commands;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task SendAsync(TCommand command);
}
