namespace ParcelLocker.Shared.Infrastructure.Modules;

public interface IModuleClient
{
    Task PublishAsync(object message);
}
