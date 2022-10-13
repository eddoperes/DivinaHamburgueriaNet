using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class PedidoDeCompra: Entity
    {

        public enum EstadoPedidoDeCompra
        {
            Cotacao = 1,
            Emitido = 2,
            Cancelado = 3,
            Entregue = 4,
            Estocado = 5
        }

        public enum EstadoPagamentoPedidoDeCompra
        {
            EmAberto = 1,
            Pago = 2
        }

        public Fornecedor Fornecedor { get; private set; }

        public EstadoPedidoDeCompra Estado { get; private set; } = EstadoPedidoDeCompra.Cotacao;

        public string Observacao { get; private set; } = string.Empty;

        public DateTime DataCriado { get; private set; }

        public DateTime DataCotacao { get; private set; }

        public DateTime DataEmitido { get; private set; }

        public DateTime DataCancelado { get; private set; }

        public DateTime DataEntregue { get; private set; }

        public DateTime DataEstocado { get; private set; }

        public EstadoPagamentoPedidoDeCompra EstadoPagamento { get; private set; } = EstadoPagamentoPedidoDeCompra.EmAberto;

        public DateTime DataPagamento { get; private set; }

        public Decimal Total { get; private set; }

    }
}
