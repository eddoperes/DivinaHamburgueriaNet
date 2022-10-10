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
    public class CardapioItemDoCardapioConfiguration : IEntityTypeConfiguration<CardapioItemDoCardapio>
    {
        public void Configure(EntityTypeBuilder<CardapioItemDoCardapio> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Preco).HasColumnType("decimal(10,2)");
        }
    }
}
