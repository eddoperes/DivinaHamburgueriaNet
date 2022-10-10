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
    public class PedidoDeliveryItemDoCardapioConfiguration : IEntityTypeConfiguration<PedidoDeliveryItemDoCardapio>
    {
        public void Configure(EntityTypeBuilder<PedidoDeliveryItemDoCardapio> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Preco).HasColumnType("decimal(10,2)");
            builder.Property(c => c.Observacao).HasMaxLength(500).IsRequired();
            builder.ToTable("PedidosDeliveryItensDoCardapio");
        }
    }
}
