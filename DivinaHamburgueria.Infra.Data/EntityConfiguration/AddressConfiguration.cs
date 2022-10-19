using DivinaHamburgueria.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DivinaHamburgueria.Domain.ValueObjects;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasNoKey();
            builder.Property(c => c.PostalCode).HasMaxLength(8).IsRequired();
            builder.Property(c => c.Street).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Complement).HasMaxLength(50).IsRequired();
            builder.Property(c => c.District).HasMaxLength(100).IsRequired();
            builder.Property(c => c.City).HasMaxLength(100).IsRequired();
            builder.Property(c => c.FederationUnity).HasMaxLength(2).IsRequired();
            builder.ToTable("Addresses");
        }
    }
}
