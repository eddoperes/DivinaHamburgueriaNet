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
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Photo).HasMaxLength(100).IsRequired();
            builder.ToTable("MenuItems");
        }
    }
}
