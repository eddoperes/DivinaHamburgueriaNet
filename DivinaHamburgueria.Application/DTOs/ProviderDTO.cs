using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace DivinaHamburgueria.Application.DTOs
{

    public class ProviderDTO
    {

        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("CNPJ")]
        public string CNPJ { get; set; } = string.Empty;

        internal DateTime? CreationDate { get; set; }

    }
}
