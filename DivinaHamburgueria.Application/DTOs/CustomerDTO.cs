using DivinaHamburgueria.Application.Hypermedia;
using DivinaHamburgueria.Application.Hypermedia.Abstract;
using System.Collections.Generic;

namespace DivinaHamburgueria.Application.DTOs
{
    public class CustomerDTO : ISupportsHypermedia
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

        public AddressDTO? Address { get; set; }

        public PhoneDTO? Phone { get; set; }

        public List<HypermediaLink> Links { get; set; } = new List<HypermediaLink>();

    }
}
