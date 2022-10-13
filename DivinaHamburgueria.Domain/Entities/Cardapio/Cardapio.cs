using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Cardapio: Entity
    {

        public enum EstadoCardapio
        {
            Ativado = 1,
            Inativado = 0
        }

        public string Nome { get; private set; } = string.Empty;

        public string Descricao { get; private set; } = string.Empty;

        public EstadoCardapio Estado { get; private set; } = EstadoCardapio.Ativado;

        public DateTime DataCriado { get; private set; }

        public DateTime DataAtivado { get; private set; }

        public DateTime DataInativado { get; private set; }

        public ICollection<CardapioItemDoCardapio> CardapiosItensDoCardapio { get; private set; }

    }

}
