using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.EntityConfiguration
{
    public class IngredientConfiguration: IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("Ingredients");
        }
    }
}
