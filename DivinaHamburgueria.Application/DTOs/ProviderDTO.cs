using DivinaHamburgueria.Application.Hypermedia;
using DivinaHamburgueria.Application.Hypermedia.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DivinaHamburgueria.Application.DTOs
{

    public class ProviderDTO: ISupportsHypermedia
    {

        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("CNPJ")]
        public string CNPJ { get; set; } = string.Empty;

        internal DateTime? CreationDate { get; set; }

        public AddressDTO? Address { get; set; }

        public PhoneDTO? Phone { get; set; }

        public List<HypermediaLink> Links { get; set; } = new List<HypermediaLink>();

    }
}
