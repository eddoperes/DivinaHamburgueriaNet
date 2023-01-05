using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Application.DTOs
{
    public class HallOrderMenuItemDTO
    {

        public int MenuItemId { get; set; }

        public decimal Price { get; set; }

        public string? Observation { get; set; }

    }
}
