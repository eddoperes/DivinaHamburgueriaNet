using DivinaHamburgueria.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    internal class ItemDoEstoqueReceitaConfiguration : IEntityTypeConfiguration<ItemDoEstoqueReceita>
    {
        public void Configure(EntityTypeBuilder<ItemDoEstoqueReceita> builder)
        {
            builder.Ignore(c => c.Nome);
            builder.HasDiscriminator<string>("Type").HasValue("C");
        }
    }
}

