using DivinaHamburgueria.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class MenuItemRecipe: MenuItem
    {

        public MenuItemRecipe(string name, string description, string photo) : base(name, description, photo)
        {
            //called by entity framework   
        }

        public MenuItemRecipe(int id, string name, string description, string photo) : base(id, name, description, photo)
        {
            //called by mapper    
        }

        public ICollection<Ingredient>? Ingredients { get; private set; }

    }
}
