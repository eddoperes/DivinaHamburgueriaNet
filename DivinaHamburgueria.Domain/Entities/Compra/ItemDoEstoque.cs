using DivinaHamburgueria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class ItemDoEstoque : Entity
    {

        public enum TipoItemDoEstoque
        {
            Receita = 1,
            Revenda = 2
        }

        public string Nome { get; private set; } = string.Empty;

        public string? Marca { get; private set; }

        public TipoItemDoEstoque Tipo { get; private set; } = TipoItemDoEstoque.Receita;

        public int Conteudo { get; private set; }

        public Unidade Unidade { get; private set; }

    }
}
