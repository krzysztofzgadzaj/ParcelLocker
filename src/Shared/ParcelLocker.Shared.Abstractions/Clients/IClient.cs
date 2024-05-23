namespace ParcelLocker.Shared.Abstractions.Clients;

public interface IClient
{
    Task<T> SendAsync<T>(string path, object arguments);
}