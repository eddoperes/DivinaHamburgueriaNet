using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Ingredient: Entity
    {

        public Eatable? Eatable { get; private set; }

        public int Quantity { get; private set; } = 0;

        public Unity? Unity { get; private set; }

    }
}
