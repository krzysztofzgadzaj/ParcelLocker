using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParcelLocker.Shared.Infrastructure.Api;
using ParcelLocker.Shared.Infrastructure.Exceptions;

namespace ParcelLocker.Shared.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        var disabledModules = new List<string>();
        using (var serviceProvider = serviceCollection.BuildServiceProvider())
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            foreach (var (key, value) in configuration.AsEnumerable())
            {
                if (!key.Contains(":module:enabled"))
                {
                    continue;
                }

                if (!bool.Parse(value))
                {
                    disabledModules.Add(key.Split(":")[0]);
                }
            }
        }

        serviceCollection
            .AddControllers()
            .ConfigureApplicationPartManager(manager =>
            {
                var removedParts = new List<ApplicationPart>();
                
                foreach (var disabledModule in disabledModules)
                {
                    var parts = manager
                        .ApplicationParts
                        .Where(x => x.Name.Contains(disabledModule, StringComparison.InvariantCultureIgnoreCase));
                    
                    removedParts.AddRange(parts);
                }

                foreach (var part in removedParts)
                {
                    manager.ApplicationParts.Remove(part);
                }

                manager
                    .FeatureProviders
                    .Add(new InternalControllerFeatureProvider());
            });
        
        // TODO - Verify if this extension is needed.
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        serviceCollection.AddExceptionHandling();

        return serviceCollection;
    }

    public static WebApplication UseInfrastructure(this WebApplication webApplication)
    {
        webApplication.UseExceptionHandling();

        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI();
        }

        return webApplication;
    }
}
