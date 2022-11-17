using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public abstract class Order: Entity
    {

        public User? User { get; private set; }

        public string Observation { get; private set; } = string.Empty;

        public Customer? Customer { get; private set; }

        public decimal Total { get; private set; }

        public DateTime CreationDate { get; private set; }


    }
}
