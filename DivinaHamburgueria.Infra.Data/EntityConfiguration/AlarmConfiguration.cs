using DivinaHamburgueria.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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
