using DivinaHamburgueria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class ItemDoCardapioConfiguration : IEntityTypeConfiguration<ItemDoCardapio>
    {
        public void Configure(EntityTypeBuilder<ItemDoCardapio> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Descricao).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Fotografia).HasMaxLength(100).IsRequired();
            builder.ToTable("ItensDoCardapio");
        }
    }
}
