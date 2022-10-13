using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class ItemDoEstoqueRevenda : ItemDoEstoque
    {

        public string Nome { get; private set; } = string.Empty;

    }
}
