using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.ValueObjects
{
    public class EnderecoFornecedor: Endereco
    {

        public Fornecedor Fornecedor { get; private set; }

    }
}
