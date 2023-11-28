using ParcelLocker.Modules.History.Api;
using ParcelLocker.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure()
    .AddHistory();

var app = builder.Build();

app.UseInfrastructure();

app.Run();
