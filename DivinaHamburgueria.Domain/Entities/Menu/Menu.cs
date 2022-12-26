using DivinaHamburgueria.Domain.Validation;
using System;
using System.Collections.Generic;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Menu: Entity
    {

        public Menu(string name, string description, MenuState state,
                    DateTime? creationDate = null, DateTime? activationDate = null, DateTime? inactivationDate = null)
        {
            //called by entity framework    
            ValidateDomain(name, description, state,
                           creationDate, activationDate, inactivationDate);
        }

        public Menu(int id, string name, string description, MenuState state,
                    DateTime? creationDate = null, DateTime? activationDate = null, DateTime? inactivationDate = null)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            //called by mapper
            ValidateDomain(name, description, state,
                           creationDate, activationDate, inactivationDate);
        }

        private void ValidateDomain(string name, string description, MenuState state,
                                    DateTime? creationDate, DateTime? activationDate, DateTime? inactivationDate)
        {
            DomainExceptionValidation.When(name.Equals(string.Empty), "Invalid name. Name must be informed.");
            DomainExceptionValidation.When(description.Equals(string.Empty), "Invalid description. Description must be informed.");
            DomainExceptionValidation.When(state < MenuState.Inactive || state > MenuState.Active, "Invalid state. Out of range 0 to 1.");
            this.Name = name;
            this.Description = description;
            this.State = state;
            this.CreationDate = creationDate;
            this.ActivationDate = activationDate;
            this.InactivationDate = inactivationDate;
        }

        public enum MenuState
        {
            Active = 1,
            Inactive = 0
        }

        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public MenuState State { get; private set; } = MenuState.Active;

        public DateTime? CreationDate { get; private set; }

        public DateTime? ActivationDate { get; private set; }

        public DateTime? InactivationDate { get; private set; }

        public ICollection<MenuMenuItem>? MenuMenuItems { get; private set; }

    }

}
