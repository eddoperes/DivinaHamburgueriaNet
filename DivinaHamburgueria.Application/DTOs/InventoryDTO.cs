using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Application.DTOs
{
    public class InventoryDTO
    {

        public int Id { get; set; }

        public int InventoryItemId { get; set; }

        public float Quantity { get; set; }

    }
}
