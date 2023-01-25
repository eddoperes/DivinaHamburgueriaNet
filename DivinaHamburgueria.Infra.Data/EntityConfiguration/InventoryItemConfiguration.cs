using DivinaHamburgueria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class InventoryItemConfiguration: IEntityTypeConfiguration<InventoryItem>
    {
       public void Configure(EntityTypeBuilder<InventoryItem> builder)
        {
            builder.Property(c => c.Brand).HasMaxLength(100);
            builder.ToTable("InventoryItems");
        }
    }
}
