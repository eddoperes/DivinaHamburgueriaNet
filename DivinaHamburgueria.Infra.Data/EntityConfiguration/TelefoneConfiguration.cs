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
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasNoKey();
            builder.Property(c => c.DDD).HasMaxLength(2).IsRequired();
            builder.Property(c => c.Numero).HasMaxLength(9).IsRequired();
            builder.ToTable("Telefones");
        }
    }
}
