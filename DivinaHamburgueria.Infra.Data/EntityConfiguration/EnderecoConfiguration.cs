using DivinaHamburgueria.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DivinaHamburgueria.Domain.ValueObjects;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasNoKey();
            builder.Property(c => c.CEP).HasMaxLength(8).IsRequired();
            builder.Property(c => c.Logradouro).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Complemento).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Bairro).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Cidade).HasMaxLength(100).IsRequired();
            builder.Property(c => c.UF).HasMaxLength(2).IsRequired();
            builder.ToTable("Enderecos");
        }
    }
}
