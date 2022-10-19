using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.ValueObjects
{
    public class ProviderPhone : Phone
    {

        public Provider? Provider { get; private set; }

    }
}
