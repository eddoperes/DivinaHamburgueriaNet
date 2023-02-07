using DivinaHamburgueria.Domain.Validation;
using System;

namespace DivinaHamburgueria.Domain.Entities
{
    public class MenuMenuItem: Entity
    {

        public MenuMenuItem(int menuItemId, decimal price, MenuMenuItemState state,
                            DateTime? creationDate = null, DateTime? activationDate = null,
                            DateTime? inactivationDate = null) {
            //called by entity framework    
            ValidateDomain(menuItemId, price, state,
                           creationDate, activationDate,
                           inactivationDate);        
        }

        public MenuMenuItem(int id, int menuItemId, decimal price, MenuMenuItemState state,
                            DateTime? creationDate = null, DateTime? activationDate = null,
                            DateTime? inactivationDate = null)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            //called by mapper  
            ValidateDomain(menuItemId, price, state,
                           creationDate, activationDate,
                           inactivationDate);
        }

        private void ValidateDomain(int menuItemId, decimal price, MenuMenuItemState state,
                                    DateTime? creationDate = null, DateTime? activationDate = null,
                                    DateTime? inactivationDate = null)
        {
            DomainExceptionValidation.When(menuItemId <= 0, "Invalid menu item id. Smaller or equal than zero.");
            DomainExceptionValidation.When(price <= 0, "Invalid price. Smaller or equal than zero.");
            DomainExceptionValidation.When(state < MenuMenuItemState.Inactive || state > MenuMenuItemState.Active, "Invalid state. Out of range 0 to 1.");
            this.MenuItemId = menuItemId;
            this.Price = price;
            this.State = state;
            this.CreationDate = creationDate;
            this.ActivationDate = activationDate;
            this.InactivationDate = inactivationDate;
        }

        public enum MenuMenuItemState
        {
            Active = 1,
            Inactive = 0
        }

        public int MenuItemId { get; private set; }

        public MenuItem? MenuItem { get; private set; }

        public decimal Price { get; private set; }

        public MenuMenuItemState State { get; private set; } = MenuMenuItemState.Active;

        public DateTime? CreationDate { get; private set; }

        public DateTime? ActivationDate { get; private set; }

        public DateTime? InactivationDate { get; private set; }

    }
}
