using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.ValueObjects
{
    public abstract class Endereco
    {

        public string CEP { get; private set; } = string.Empty;

        public string Logradouro { get; private set; } = string.Empty;

        public int Numero { get; private set; }

        public string Complemento { get; private set; } = string.Empty;

        public string Bairro { get; private set; } = string.Empty;

        public string Cidade { get; private set; } = string.Empty;

        public string UF { get; private set; } = string.Empty;

    }
}
