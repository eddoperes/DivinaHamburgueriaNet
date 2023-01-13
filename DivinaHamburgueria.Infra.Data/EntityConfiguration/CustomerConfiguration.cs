using DivinaHamburgueria.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.CPF).HasMaxLength(12).IsRequired();

            //builder.OwnsOne(c => c.Address);
            builder.OwnsOne(c => c.Address).Property(c => c.PostalCode).HasMaxLength(8).IsRequired();
            builder.OwnsOne(c => c.Address).Property(c => c.Street).HasMaxLength(50).IsRequired();
            builder.OwnsOne(c => c.Address).Property(c => c.Complement).HasMaxLength(50).IsRequired();
            builder.OwnsOne(c => c.Address).Property(c => c.District).HasMaxLength(100).IsRequired();
            builder.OwnsOne(c => c.Address).Property(c => c.City).HasMaxLength(100).IsRequired();
            builder.OwnsOne(c => c.Address).Property(c => c.FederationUnity).HasMaxLength(2).IsRequired();

            //builder.OwnsMany(c => c.Phones);
            builder.OwnsOne(c => c.Phone).Property(c => c.DDD).HasMaxLength(2).IsRequired();
            builder.OwnsOne(c => c.Phone).Property(c => c.Number).HasMaxLength(9).IsRequired();

            builder.ToTable("Customers");
        }    
    }
}
