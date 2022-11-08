using System;

namespace DivinaHamburgueria.Application.DTOs
{
    public class PurchaseOrderInventoryItemDTO
    {

        public int Id { get; set; }

        public int InventoryItemId { get; set; }

        //public InventoryItem? InventoryItem { get; set; }

        public Decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public Decimal TotalPrice { get; set; }

        internal bool Stocked { get; set; }



    }
}
