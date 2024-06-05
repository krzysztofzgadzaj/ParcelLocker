using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OutPost.Bootstrapper;
using OutPost.Modules.Logistics.Infrastructure.Persistence;
using Testcontainers.PostgreSql;
using Xunit;

namespace Outpost.Modules.Logistics.Tests.Integration;

public abstract class BaseTestClass : IClassFixture<WebApplicationFactory<Program>>, IAsyncLifetime
{
    protected readonly WebApplicationFactory<Program> Factory;
    private readonly PostgreSqlContainer _postgres;

    protected BaseTestClass()
    {
        _postgres = new PostgreSqlBuilder().Build();

        Factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder
            => builder.ConfigureTestServices(services
                =>
            {
                // Remove AppDbContext
                var descriptor =
                    services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<LogisticsContext>));
                if (descriptor != null) services.Remove(descriptor);

                // Add DB context pointing to test container
                services.AddDbContext<LogisticsContext>(options =>
                {
                    options.UseNpgsql(_postgres.GetConnectionString());
                });

                // Ensure schema gets created
                var serviceProvider = services.BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<LogisticsContext>();
                context.Database.EnsureCreated();
            }));
    }

    public Task InitializeAsync()
    {
        return _postgres.StartAsync();
    }

    public Task DisposeAsync()
    {
        return _postgres.DisposeAsync().AsTask();
    }
}
