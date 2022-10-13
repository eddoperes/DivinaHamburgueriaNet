using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class PedidoSalaoItemDoCardapio: Entity
    {

        public PedidoSalao? PedidoSalao { get; private set; }

        public ItemDoCardapio? ItemDoCardapio { get; private set; }

        public decimal Preco { get; private set; }

        public string Observacao { get; private set; } = string.Empty;

    }
}
