using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class PedidoDelivery: Pedido
    {

        public enum EstadoPedidoDelivery
        {
            Emitido = 1,
            Cancelado = 2,
            Embalado = 3,
            Entregue = 4
        }

        public enum EstadoPagamentoPedidoDelivery
        {
            EmAberto = 1,
            Pago = 2
        }

        public EstadoPedidoDelivery Estado = EstadoPedidoDelivery.Emitido;

        public DateTime DataEmitido { get; private set; }

        public DateTime DataCancelado { get; private set; }

        public DateTime DataEmbalado { get; private set; }

        public DateTime DataEntregue { get; private set; }

        public EstadoPagamentoPedidoDelivery Pagamento { get; private set; } = EstadoPagamentoPedidoDelivery.EmAberto;

        public DateTime DataPagamento { get; private set; }

    }
}
