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
    public class HallOrderMenuItemConfiguration : IEntityTypeConfiguration<HallOrderMenuItem>
    {
        public void Configure(EntityTypeBuilder<HallOrderMenuItem> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Observation).HasMaxLength(500);
            builder.Property(c => c.Price).HasColumnType("decimal(10,2)");
            builder.ToTable("HallOrdersMenuItems");
        }
    }
}
