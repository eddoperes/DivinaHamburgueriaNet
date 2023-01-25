using DivinaHamburgueria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Observation).HasMaxLength(500);
            builder.Property(c => c.Total).HasColumnType("decimal(10,2)");
            builder.ToTable("PurchaseOrders");
        }
    }
}
