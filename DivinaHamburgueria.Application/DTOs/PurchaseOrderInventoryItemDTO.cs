using System;

namespace DivinaHamburgueria.Application.DTOs
{
    public class PurchaseOrderInventoryItemDTO
    {

        public int Id { get; set; }

        public int InventoryItemId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public bool Stocked { get; set; }



    }
}
