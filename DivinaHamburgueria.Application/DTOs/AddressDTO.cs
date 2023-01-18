using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Application.DTOs
{
    public class AddressDTO
    {

        public string PostalCode { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public int Number { get; set; }

        public string Complement { get; set; } = string.Empty;

        public string District { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string FederationUnity { get; set; } = string.Empty;


    }
}
