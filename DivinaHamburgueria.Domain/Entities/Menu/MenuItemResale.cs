using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class MenuItemResale: MenuItem
    {

        public InventoryItem? InventoryItem { get; private set; }

    }
}
