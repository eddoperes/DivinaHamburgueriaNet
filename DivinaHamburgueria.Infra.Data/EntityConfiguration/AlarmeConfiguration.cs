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
    public class AlarmeConfiguration : IEntityTypeConfiguration<Alarme>
    {
        public void Configure(EntityTypeBuilder<Alarme> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("Alarmes");
        }
    }
}
