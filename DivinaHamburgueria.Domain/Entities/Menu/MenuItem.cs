using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public abstract class MenuItem: Entity
    {

        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public string Photo { get; private set; } = string.Empty;

    }
}
