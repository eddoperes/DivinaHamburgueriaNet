﻿using DivinaHamburgueria.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class PedidoSalaoItemDoCardapioConfiguration : IEntityTypeConfiguration<PedidoSalaoItemDoCardapio>
    {
        public void Configure(EntityTypeBuilder<PedidoSalaoItemDoCardapio> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Observacao).HasMaxLength(500);
            builder.Property(c => c.Preco).HasColumnType("decimal(10,2)");
            builder.ToTable("PedidosSalaoItensDoCardapio");
        }
    }
}
