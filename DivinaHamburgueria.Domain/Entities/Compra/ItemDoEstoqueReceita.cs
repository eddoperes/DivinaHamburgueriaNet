using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class ItemDoEstoqueReceita : ItemDoEstoque
    {

        public int ComestivelId { get; private set; }

        public Comestivel? Comestivel { get; private set; }

    }
}
