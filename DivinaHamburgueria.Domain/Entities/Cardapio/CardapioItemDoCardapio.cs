using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class CardapioItemDoCardapio: Entity
    {

        public enum EstadoItemDoCardapio
        {
            Ativado = 1,
            Inativado = 0
        }

        public Cardapio Cardapio { get; private set; }

        public ItemDoCardapio ItemDoCardapio  { get; private set; }

        public decimal Preco { get; private set; }

        public EstadoItemDoCardapio Estado { get; private set; } = EstadoItemDoCardapio.Ativado;

        public DateTime DataCriado { get; private set; }

        public DateTime DataAtivado { get; private set; }

        public DateTime DataInativado { get; private set; }

    }
}
