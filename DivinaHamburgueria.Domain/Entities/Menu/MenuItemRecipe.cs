using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class MenuItemRecipe: MenuItem
    {
        public ICollection<Ingredient>? Ingredients { get; private set; }

    }
}
