using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.ValueObjects
{

    public class CustomerAddress: Address
    {

        public Customer? Customer { get; private set; }

    }

}
