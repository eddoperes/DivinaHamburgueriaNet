using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class PedidoDeliveryItemDoCardapio: Entity
    {

        public PedidoDelivery? PedidoDelivery { get; private set; }

        public ItemDoCardapio? ItemDoCardapio { get; private set; }

        public decimal Preco { get; private set; }

        public string Observacao { get; private set; } = string.Empty;

    }
}
