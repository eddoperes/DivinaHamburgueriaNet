using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Menu: Entity
    {

        public enum MenuState
        {
            Active = 1,
            Inactive = 0
        }

        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public MenuState State { get; private set; } = MenuState.Active;

        public DateTime CreationDate { get; private set; }

        public DateTime ActivationDate { get; private set; }

        public DateTime InactivationDate { get; private set; }

        public ICollection<MenuMenuItem>? MenuMenuItems { get; private set; }

    }

}
