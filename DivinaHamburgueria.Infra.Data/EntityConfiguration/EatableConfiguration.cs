using DivinaHamburgueria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class EatableConfiguration : IEntityTypeConfiguration<Eatable>
    {
        public void Configure(EntityTypeBuilder<Eatable> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.ToTable("Eatables");
        }
    }
}
