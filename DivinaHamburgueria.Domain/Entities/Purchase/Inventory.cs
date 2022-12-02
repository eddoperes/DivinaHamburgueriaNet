using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Inventory : Entity
    {

        public int InventoryItemId { get; private set; }

        public InventoryItem? InventoryItem { get; private set; }

        public float Quantity { get; private set; }

    }
}
