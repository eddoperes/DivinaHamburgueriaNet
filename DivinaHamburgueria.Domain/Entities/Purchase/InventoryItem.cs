using DivinaHamburgueria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using static DivinaHamburgueria.Domain.Entities.Menu;

namespace DivinaHamburgueria.Domain.Entities
{
    public class InventoryItem : Entity
    {

        public enum ItemType
        {
            Recipe = 1,
            Resale = 2
        }

        public string? Brand { get; private set; }

        public int Content { get; private set; }

        public int UnityId { get; private set; }

        public Unity? Unity { get; private set; }

        public ItemType Type { get; private set; } = ItemType.Recipe;

        public int EatableId { get; private set; }

        public Eatable? Eatable { get; private set; }

        public String Name
        {
            get
            {
                if (Eatable != null)
                    return Eatable.Name;
                return "";
            }
        }

        public void NotificarComestivel(Eatable? eatable)
        {
            Eatable = eatable;
        }

    }
}
