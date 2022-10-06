using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.ValueObjects
{
    public abstract class Telefone
    {

        public string DDD { get; private set; } = string.Empty;

        public string Numero { get; private set; } = string.Empty;

    }
}
