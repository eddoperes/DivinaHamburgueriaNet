using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class PedidoSalao
    {

        public enum EstadoPedidoSalao
        {
            Emitido = 1,
            Cancelado = 2,
            Entregue = 3
        }

        public EstadoPedidoSalao Estado = EstadoPedidoSalao.Emitido;

        public DateTime DataEmitido { get; private set; }

        public DateTime DataCancelado { get; private set; }

        public DateTime DataEntregue { get; private set; }

    }
}
