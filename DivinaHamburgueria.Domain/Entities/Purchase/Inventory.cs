using DivinaHamburgueria.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using static DivinaHamburgueria.Domain.Entities.PurchaseOrder;

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

        public int InventoryItemId { get; private set; }

        public InventoryItem? InventoryItem { get; private set; }

        public float Quantity { get; private set; }

        private void ValidateDomain(int inventoryItemId, float quantity)
        {
            //DomainExceptionValidation.When(providerId <= 0, "Invalid provider id. Smaller or equal than zero.");
            //DomainExceptionValidation.When(total <= 0, "Invalid total. Smaller or equal than zero.");
            //DomainExceptionValidation.When(state < PurchaseOrderState.Quotation || state > PurchaseOrderState.Stocked, "Invalid state. Out of range 1 to 5.");
            //DomainExceptionValidation.When(payment < PurchaseOrderPayment.Opened || payment > PurchaseOrderPayment.Paid, "Invalid payment. Out of range 1 to 2.");
            this.InventoryItemId = inventoryItemId;
            this.Quantity = quantity;            
        }

        public void addQuantity(float quantity)
        {
            this.Quantity += quantity;
        }


    }
}
