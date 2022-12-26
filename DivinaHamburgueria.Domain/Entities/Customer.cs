using DivinaHamburgueria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Customer: Entity
    {

        public string Name { get; private set; } = string.Empty;

        public string CPF { get; private set; } = string.Empty;

        public DateTime? CreationDate { get; private set; }

    }
}
