using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OutPost.Shared.Infrastructure.Api;
using OutPost.Shared.Infrastructure.Commands;
using OutPost.Shared.Infrastructure.Events;
using OutPost.Shared.Infrastructure.Exceptions;
using OutPost.Shared.Infrastructure.Kernel;
using OutPost.Shared.Infrastructure.Messaging;
using OutPost.Shared.Infrastructure.Modules;
using OutPost.Shared.Infrastructure.Queries;
using OutPost.Shared.Infrastructure.TextSerializer;
using OutPost.Shared.Infrastructure.Localization;

namespace OutPost.Shared.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IEnumerable<Assembly> assemblies, IConfiguration configuration)
    {
        serviceCollection.AddExceptionHandling();
        serviceCollection.AddEvents(assemblies);
        serviceCollection.AddModuleRegistry(assemblies);
        serviceCollection.AddTextSerializer();
        serviceCollection.AddQueries(assemblies);
        serviceCollection.AddCommands(assemblies);
        serviceCollection.AddDomainEvents(assemblies);
        serviceCollection.AddMessageBroker(configuration);
        serviceCollection.AddGeographicalLocalization();
        
        var disabledModules = new List<string>();
        using (var serviceProvider = serviceCollection.BuildServiceProvider())
        {
            var appConfiguration = serviceProvider.GetRequiredService<IConfiguration>();
            foreach (var (key, value) in appConfiguration.AsEnumerable())
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
            .AddControllers(options => options.Conventions.Add(new KebabCaseRouteConvention()))
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
        serviceCollection.AddSwaggerGen(options =>
        {
            options.TagActionsBy(api =>
            {
                if (api.GroupName != null)
                {
                    return new[] { api.GroupName };
                }

                var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                if (controllerActionDescriptor != null)
                {
                    return new[] { controllerActionDescriptor.ControllerName };
                }

                throw new InvalidOperationException("Unable to determine tag for endpoint.");
            });
            options.DocInclusionPredicate((name, api) => true);
        });

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
