using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.ValueObjects
{
    public class CustomerPhone: Phone
    {

        public Customer? Customer { get; private set; }

    }
}
