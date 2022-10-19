using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;
using static DivinaHamburgueria.Domain.Entities.MenuMenuItem;

namespace DivinaHamburgueria.Application.DTOs
{
    public class MenuMenuItemDTO
    {

        public int Id { get; set; }

        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Range(0, 1)]
        [DisplayName("State")]
        public int State { get; set; }

        [DisplayName("MenuItemId")]
        public int MenuItemId { get; set; }

    }
}
