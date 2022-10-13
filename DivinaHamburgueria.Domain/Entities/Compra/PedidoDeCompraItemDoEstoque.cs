using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class PedidoDeCompraItemDoEstoque: Entity
    {

        public PedidoDeCompra? PedidoDeCompra { get; private set; }

        public ItemDoEstoque? ItemDoEstoque { get; private set; }

        public Decimal PrecoUnitario { get; private set; }

        public int Quantidade { get; private set; }

        public Decimal PrecoTotal { get; private set; }

        public bool Estocado { get; private set; }

    }
}
