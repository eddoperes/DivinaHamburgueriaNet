using DivinaHamburgueria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Alarm: Entity
    {

        public Eatable? Eatable { get; private set; }

        public int MinimumQuantity { get; private set; }

        public Unity? Unity { get; private set; }

        public int ValidityInDays { get; private set; }

    }
}
