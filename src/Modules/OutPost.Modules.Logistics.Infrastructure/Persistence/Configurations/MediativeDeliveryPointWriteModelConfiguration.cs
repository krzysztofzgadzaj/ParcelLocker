using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutPost.Modules.Logistics.Infrastructure.Persistence.WriteModels;

namespace OutPost.Modules.Logistics.Infrastructure.Persistence.Configurations;

public class MediativeDeliveryPointWriteModelConfiguration : IEntityTypeConfiguration<MediativeDeliveryPointWriteModel>
{
    public void Configure(EntityTypeBuilder<MediativeDeliveryPointWriteModel> builder)
    {
        builder.HasKey(x => x.MdpId);
    }
}
