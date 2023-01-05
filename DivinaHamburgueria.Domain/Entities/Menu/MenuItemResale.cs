using DivinaHamburgueria.Domain.Validation;

namespace DivinaHamburgueria.Domain.Entities
{
    public class MenuItemResale: MenuItem
    {

        public MenuItemResale(string name, string description, 
                              string photo, int inventoryItemId) : base(name, description, photo)
        {
            //called by entity framework   
            ValidateDomain(inventoryItemId);
        }

        public MenuItemResale(int id, string name, string description, 
                              string photo, int inventoryItemId) : base(id, name, description, photo)
        {
            //called by mapper    
            ValidateDomain(inventoryItemId);
        }

        private void ValidateDomain(int inventoryItemId)
        {
            DomainExceptionValidation.When(inventoryItemId <= 0, "Invalid inventory item id. Smaller or equal than zero.");
            this.InventoryItemId = inventoryItemId;           
        }


        public int InventoryItemId { get; private set; }

        public InventoryItem? InventoryItem { get; private set; }

    }
}
