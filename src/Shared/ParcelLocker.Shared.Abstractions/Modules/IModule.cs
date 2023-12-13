using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ParcelLocker.Shared.Abstractions.Modules;

public interface IModule
{
    string Name { get; }
    string Path { get; }
    void Register(IServiceCollection serviceCollection);
    void Use(WebApplication webApplication);
}
