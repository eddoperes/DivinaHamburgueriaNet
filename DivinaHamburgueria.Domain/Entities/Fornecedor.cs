using DivinaHamburgueria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Fornecedor: Entity
    {

        public string Nome { get; private set; } = string.Empty;

        public string CNPJ { get; private set; } = string.Empty;

        public DateTime DataCriado { get; private set; }

    }


}
