using DivinaHamburgueria.Domain.Validation;
using System;

namespace DivinaHamburgueria.Domain.Entities
{
    public class PurchaseOrderInventoryItem: Entity
    {

        public PurchaseOrderInventoryItem(int inventoryItemId, Decimal unitPrice,
                                          int quantity, decimal totalPrice)
        {
            //called by entity framework
            ValidateDomain(inventoryItemId, unitPrice, quantity, totalPrice);
        }

        public PurchaseOrderInventoryItem(int id, int inventoryItemId, decimal unitPrice,
                                          int quantity, decimal totalPrice)
        {
            //called by mapper
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            Id = id;
            ValidateDomain(inventoryItemId, unitPrice, quantity, totalPrice);
        }

        private void ValidateDomain(int inventoryItemId, decimal unitPrice,
                                    int quantity, decimal totalPrice)
        {
            DomainExceptionValidation.When(inventoryItemId <= 0, "Invalid inventory item id. Smaller or equal than zero.");
            DomainExceptionValidation.When(unitPrice <= 0, "Invalid unit price. Smaller or equal than zero.");
            DomainExceptionValidation.When(quantity <= 0, "Invalid quantity. Smaller or equal than zero.");
            DomainExceptionValidation.When(totalPrice <= 0, "Invalid total price. Smaller or equal than zero.");
            InventoryItemId = inventoryItemId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            TotalPrice = totalPrice;
            //Stocked = stocked;
        }

        public int InventoryItemId { get; private set; }

        public InventoryItem? InventoryItem { get; private set; }

        public decimal UnitPrice { get; private set; }

        public int Quantity { get; private set; }

        public decimal TotalPrice { get; private set; }

        //public bool Stocked { get; private set; }

        //public void RegisterStocked()
        //{
        //    Stocked = true;
        //}

    }
}
