using DivinaHamburgueria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class CardapioConfiguration : IEntityTypeConfiguration<Cardapio>
    {
        public void Configure(EntityTypeBuilder<Cardapio> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Descricao).HasMaxLength(100).IsRequired();
            builder.ToTable("Cardapios");
        }
    }
}
