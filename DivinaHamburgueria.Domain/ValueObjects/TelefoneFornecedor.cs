using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.ValueObjects
{
    public class TelefoneFornecedor : Telefone
    {

        public Fornecedor? Fornecedor { get; private set; }

    }
}
