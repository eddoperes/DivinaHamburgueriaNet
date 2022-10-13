using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class ItemDoCardapioReceita: ItemDoCardapio
    {

        public ICollection<Ingrediente> Ingredientes { get; private set; }

    }
}
