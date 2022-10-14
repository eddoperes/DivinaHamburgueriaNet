using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class ItemDoCardapioRevenda: ItemDoCardapio
    {

        public ItemDoEstoque? ItemDoEstoque { get; private set; }

    }
}
