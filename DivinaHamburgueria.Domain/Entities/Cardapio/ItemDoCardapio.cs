using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public abstract class ItemDoCardapio: Entity
    {

        public string Nome { get; private set; } = string.Empty;

        public string Descricao { get; private set; } = string.Empty;

        public string Fotografia { get; private set; } = string.Empty;

    }
}
