using DivinaHamburgueria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class PurchaseOrderInventoryItemConfiguration : IEntityTypeConfiguration<PurchaseOrderInventoryItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderInventoryItem> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.UnitPrice).HasColumnType("decimal(10,2)");
            builder.Property(c => c.TotalPrice).HasColumnType("decimal(10,2)");
            builder.ToTable("PurchaseOrdersInventoryItems");
        }
    }
}
