using DivinaHamburgueria.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasNoKey();
            builder.Property(c => c.DDD).HasMaxLength(2).IsRequired();
            builder.Property(c => c.Number).HasMaxLength(9).IsRequired();
            builder.ToTable("Phones");
        }
    }
}
