using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParcelLocker.Shared.Infrastructure.Api;
using ParcelLocker.Shared.Infrastructure.Exceptions;

namespace ParcelLocker.Shared.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddControllers()
            .ConfigureApplicationPartManager(manager => 
                manager
                    .FeatureProviders
                    .Add(new InternalControllerFeatureProvider()));
        
        // TODO - Verify if this extension is needed.
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        serviceCollection.AddExceptionHandling();

        return serviceCollection;
    }

    public static WebApplication UseInfrastructure(this WebApplication webApplication)
    {
        webApplication.UseExceptionHandling();
        webApplication.MapControllers();

        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI();
        }

        return webApplication;
    }
}
