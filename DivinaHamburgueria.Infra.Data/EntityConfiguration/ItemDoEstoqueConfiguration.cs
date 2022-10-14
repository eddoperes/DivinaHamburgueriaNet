using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class ItemDoEstoqueConfiguration: IEntityTypeConfiguration<ItemDoEstoque>
    {
       public void Configure(EntityTypeBuilder<ItemDoEstoque> builder)
        {
            builder.Property(c => c.Marca).HasMaxLength(100);
            builder.ToTable("ItensDoEstoque");
        }
    }
}
