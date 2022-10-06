using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public abstract class Pedido: Entity
    {

        public Usuario Usuario { get; private set; }

        public string Observacao { get; private set; } = string.Empty;

        public Cliente Cliente { get; private set; }

        public int Total { get; private set; }

        public DateTime DataCriado { get; private set; }


    }
}
