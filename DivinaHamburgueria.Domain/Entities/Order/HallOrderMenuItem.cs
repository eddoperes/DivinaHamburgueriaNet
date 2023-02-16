using DivinaHamburgueria.Domain.Validation;

namespace DivinaHamburgueria.Domain.Entities
{
    public class HallOrderMenuItem: Entity
    {

        public HallOrderMenuItem(int menuItemId, decimal price, string? observation = null)
        {
            //called by entity framework 
            ValidateDomain(menuItemId, price, observation);
        }

        public HallOrderMenuItem(int id, int menuItemId, decimal price, string? observation = null)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            //called by mapper 
            ValidateDomain(menuItemId, price, observation);
        }

        private void ValidateDomain(int menuItemId, decimal price, string? observation = null)
        {
            DomainExceptionValidation.When(menuItemId <= 0, "Invalid menu item Id. Smaller or equal than zero.");
            DomainExceptionValidation.When(price <= 0, "Invalid price. Smaller or equal than zero.");
            this.MenuItemId = menuItemId;
            this.Price = price;
            this.Observation = observation;
        }

        public int MenuItemId { get; private set; }

        public MenuItem? MenuItem { get; set; }

        public decimal Price { get; private set; }

        public string? Observation { get; private set; }

    }
}
