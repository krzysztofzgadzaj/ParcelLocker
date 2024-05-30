using Microsoft.EntityFrameworkCore;
using OutPost.Modules.Logistics.Infrastructure.Persistence.WriteModels;

namespace OutPost.Modules.Logistics.Infrastructure.Persistence;

public class LogisticsContext : DbContext
{
    public LogisticsContext(DbContextOptions<LogisticsContext> options) : base(options)
    {
    }
    
    public DbSet<MediativeDeliveryPointWriteModel> MediativeDeliveryPointsPoints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LogisticsContext).Assembly);
    }
}
