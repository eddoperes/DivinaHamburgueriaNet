using DivinaHamburgueria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Provider: Entity
    {

        public string Name { get; private set; } = string.Empty;

        public string CNPJ { get; private set; } = string.Empty;

        public DateTime CreationDate { get; private set; }

    }


}
