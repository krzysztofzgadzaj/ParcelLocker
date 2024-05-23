namespace OutPost.Shared.Infrastructure.Modules.ModuleRegistry;

public interface IModuleClient
{
    Task PublishAsync(object message);
    Task<T> SendAsync<T>(string path, object args);
}
