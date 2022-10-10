﻿using DivinaHamburgueria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class PedidoDeCompraConfiguration : IEntityTypeConfiguration<PedidoDeCompra>
    {
        public void Configure(EntityTypeBuilder<PedidoDeCompra> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Observacao).HasMaxLength(500);
            builder.Property(c => c.Total).HasColumnType("decimal(10,2)");
            builder.ToTable("PedidosDeCompra");
        }
    }
}
