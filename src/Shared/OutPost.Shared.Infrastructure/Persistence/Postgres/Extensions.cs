using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OutPost.Shared.Infrastructure.Persistence.Postgres;

public static class Extensions
{
    public static IServiceCollection AddPostgres<T>(this IServiceCollection serviceCollection) 
        where T : DbContext
    {
        var postgresOptions = serviceCollection.GetOptions<PostgresOptions>("Postgres");
        serviceCollection.AddDbContext<T>(options => options.UseNpgsql(postgresOptions.ConnectionString));

        return serviceCollection;
    }
}
