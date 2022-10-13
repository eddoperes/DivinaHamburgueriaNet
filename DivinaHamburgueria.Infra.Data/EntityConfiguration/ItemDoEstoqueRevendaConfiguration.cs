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
    public class ItemDoEstoqueRevendaConfiguration : IEntityTypeConfiguration<ItemDoEstoqueRevenda>
    {
        public void Configure(EntityTypeBuilder<ItemDoEstoqueRevenda> builder)
        {
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
        }        
    }
}
