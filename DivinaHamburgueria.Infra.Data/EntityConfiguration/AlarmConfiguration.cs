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
    public class AlarmConfiguration : IEntityTypeConfiguration<Alarm>
    {
        public void Configure(EntityTypeBuilder<Alarm> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("Alarms");
        }
    }
}
