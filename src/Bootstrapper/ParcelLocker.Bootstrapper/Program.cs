using Bootstrapper;
using ParcelLocker.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();

var assemblies = ModuleLoader.GetAssemblies();
var modules = ModuleLoader.GetModules(assemblies);

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
