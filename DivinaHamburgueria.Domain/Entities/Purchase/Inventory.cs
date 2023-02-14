using DivinaHamburgueria.Domain.Validation;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Inventory : Entity
    {

        public Inventory(int inventoryItemId, float quantity)
        {
            //called by entity framework
            ValidateDomain(inventoryItemId, quantity);
        }

        public Inventory(int id, int inventoryItemId, float quantity)
        {
            //called by mapper
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            ValidateDomain(inventoryItemId, quantity);
        }

        private void ValidateDomain(int inventoryItemId, float quantity)
        {
            DomainExceptionValidation.When(inventoryItemId <= 0, "Invalid inventory item id. Smaller or equal than zero.");
            this.InventoryItemId = inventoryItemId;
            this.Quantity = quantity;
        }

        public int InventoryItemId { get; private set; }

        public InventoryItem? InventoryItem { get; private set; }

        public float Quantity { get; private set; }

        public void addQuantity(float quantity)
        {
            this.Quantity += quantity;
        }

        public void subtractQuantity(float quantity)
        {
            this.Quantity -= quantity;
        }


    }
}
