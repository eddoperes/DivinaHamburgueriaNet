using DivinaHamburgueria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Alarme: Entity
    {

        public Comestivel? Comestivel { get; private set; }

        public int QuantidadeMinima { get; private set; }

        public Unidade? Unidade { get; private set; }

        public int ValidadeEmDias { get; private set; }

    }
}
