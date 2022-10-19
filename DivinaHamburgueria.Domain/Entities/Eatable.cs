using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Eatable: Entity
    {

        public Eatable(string name)
        {
            Name = name;
        }

        public string Name { get; private set; } = string.Empty;

    }
}
