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
    public class PedidoDeCompraItemDoEstoqueConfiguration : IEntityTypeConfiguration<PedidoDeCompraItemDoEstoque>
    {
        public void Configure(EntityTypeBuilder<PedidoDeCompraItemDoEstoque> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.PrecoUnitario).HasColumnType("decimal(10,2)");
            builder.Property(c => c.PrecoTotal).HasColumnType("decimal(10,2)");
            builder.ToTable("PedidosDeCompraItensDoEstoque");
        }
    }
}
