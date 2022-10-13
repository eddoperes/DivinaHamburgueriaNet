using DivinaHamburgueria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class ItemDoEstoque : Entity
    {

        public string? Marca { get; private set; }

        public int Conteudo { get; private set; }

        public int UnidadeId { get; private set; }

        public Unidade? Unidade { get; private set; }

    }
}
