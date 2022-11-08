using System;

namespace DivinaHamburgueria.Domain.Entities
{
    public class PurchaseOrderInventoryItem: Entity
    {

        //public PurchaseOrder? PurchaseOrder { get; private set; }

        public int InventoryItemId { get; private set; }

        public InventoryItem? InventoryItem { get; private set; }

        public Decimal UnitPrice { get; private set; }

        public int Quantity { get; private set; }

        public Decimal TotalPrice { get; private set; }

        public bool Stocked { get; private set; }

    }
}
