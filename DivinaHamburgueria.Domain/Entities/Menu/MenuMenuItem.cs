using System;

namespace DivinaHamburgueria.Domain.Entities
{
    public class MenuMenuItem: Entity
    {

        public enum MenuItemState
        {
            Active = 1,
            Inactive = 0
        }

        public Menu? Menu { get; private set; }

        public MenuItem? MenuItem { get; private set; }

        public decimal Price { get; private set; }

        public MenuItemState State { get; private set; } = MenuItemState.Active;

        public DateTime CreationDate { get; private set; }

        public DateTime ActivationDate { get; private set; }

        public DateTime InactivationDate { get; private set; }

    }
}
