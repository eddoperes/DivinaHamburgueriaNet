using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.ValueObjects
{
    public abstract class Phone
    {

        public string DDD { get; private set; } = string.Empty;

        public string Number { get; private set; } = string.Empty;

        public DateTime CreationDate { get; private set; }

    }
}
