using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class HallOrderMenuItem: Entity
    {

        //public HallOrder? HallOrder { get; private set; }

        public int MenuItemId { get; private set; }

        public MenuItem? MenuItem { get; private set; }

        public decimal Price { get; private set; }

        public string Observation { get; private set; } = string.Empty;

    }
}
