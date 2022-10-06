using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Estoque : Entity
    {

        public ItemDoEstoque ItemDoEstoque { get; private set; }

        public int Quantidade { get; private set; }

    }
}
