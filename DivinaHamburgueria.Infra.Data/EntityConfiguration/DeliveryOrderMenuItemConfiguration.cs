using DivinaHamburgueria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class DeliveryOrderMenuItemConfiguration : IEntityTypeConfiguration<DeliveryOrderMenuItem>
    {
        public void Configure(EntityTypeBuilder<DeliveryOrderMenuItem> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Price).HasColumnType("decimal(10,2)");
            builder.Property(c => c.Observation).HasMaxLength(500).IsRequired();
            builder.ToTable("DeliveryOrdersMenuItems");
        }
    }
}
