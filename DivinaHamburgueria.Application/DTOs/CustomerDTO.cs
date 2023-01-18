using DivinaHamburgueria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Application.DTOs
{
    public class CustomerDTO
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

        public AddressDTO? Address { get; set; }

        public PhoneDTO? Phone { get; set; }

    }
}
