using Bootstrapper;
using ParcelLocker.Shared.Infrastructure;
using ParcelLocker.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);

var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.RegisterModuleSettings(builder.Environment.EnvironmentName);
var configuration = configurationBuilder.Build();

builder.Services.AddSingleton<IConfiguration>(configuration);

var assemblies = ModuleLoader.GetModuleAssemblies(configuration);
var modules = ModuleLoader.GetModules(assemblies);

builder.Services.AddInfrastructure(assemblies, configuration);

foreach (var module in modules)
{
    module.Register(builder.Services);
}

var app = builder.Build();

app.UseInfrastructure();

foreach (var module in modules)
{
    module.Use(app);
}

app.MapControllers();

app.Run();
