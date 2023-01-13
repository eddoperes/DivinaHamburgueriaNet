using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.ValueObjects
{
    public class Address
    {

        public string PostalCode { get; private set; } = string.Empty;

        public string Street { get; private set; } = string.Empty;

        public int Number { get; private set; }

        public string Complement { get; private set; } = string.Empty;

        public string District { get; private set; } = string.Empty;

        public string City { get; private set; } = string.Empty;

        public string FederationUnity { get; private set; } = string.Empty;

    }
}
