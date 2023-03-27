using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using DivinaHamburgueria.Application.Hypermedia.Abstract;
using DivinaHamburgueria.Application.Hypermedia;
using System.Collections.Generic;

namespace DivinaHamburgueria.Application.DTOs
{
    public class MenuItemResaleDTO: ISupportsHypermedia
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; } = String.Empty;

        [MaxLength(100)]
        [DisplayName("Description")]
        public string Description { get; set; } = String.Empty;

        [DisplayName("Photo")]
        public string Photo { get; set; } = String.Empty;

        [DisplayName("InventoryItemId")]
        public int InventoryItemId { get; set; }

        public List<HypermediaLink> Links { get; set; } = new List<HypermediaLink>();

    }
}
