using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests
{
    public class PurchaseOrderInventoryItemUnitTest
    {

        [Fact]
        public void CreatePurchaseOrderInventoryItem_WithValidParameters_ObjectValidState()
        {
            Action action = () => new PurchaseOrderInventoryItem(id: 1, 
                                                                 inventoryItemId: 1, 
                                                                 unitPrice: 1,
                                                                 quantity: 1, 
                                                                 totalPrice: 1, 
                                                                 stocked: false);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreatePurchaseOrderInventoryItem_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new PurchaseOrderInventoryItem(id: -1,
                                                                 inventoryItemId: 1,
                                                                 unitPrice: 1,
                                                                 quantity: 1,
                                                                 totalPrice: 1,
                                                                 stocked: false);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreatePurchaseOrderInventoryItem_NegativeInventoryItemId_DomainExceptionInvalid()
        {
            Action action = () => new PurchaseOrderInventoryItem(id: 1,
                                                                 inventoryItemId: -1,
                                                                 unitPrice: 1,
                                                                 quantity: 1,
                                                                 totalPrice: 1,
                                                                 stocked: false);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid inventory item id. Smaller or equal than zero.");
        }

        [Fact]
        public void CreatePurchaseOrderInventoryItem_NoPositiveUnitPrice_DomainExceptionInvalid()
        {
            Action action = () => new PurchaseOrderInventoryItem(id: 1,
                                                                 inventoryItemId: 1,
                                                                 unitPrice: 0,
                                                                 quantity: 1,
                                                                 totalPrice: 1,
                                                                 stocked: false);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()                                                      
                                        .WithMessage("Invalid unit price. Smaller or equal than zero.");
        }

        [Fact]
        public void CreatePurchaseOrderInventoryItem_NoPositiveQuantity_DomainExceptionInvalid()
        {
            Action action = () => new PurchaseOrderInventoryItem(id: 1,
                                                                 inventoryItemId: 1,
                                                                 unitPrice: 1,
                                                                 quantity: 0,
                                                                 totalPrice: 1,
                                                                 stocked: false);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid quantity. Smaller or equal than zero.");
        }

        [Fact]
        public void CreatePurchaseOrderInventoryItem_NoPositiveTotalPrice_DomainExceptionInvalid()
        {
            Action action = () => new PurchaseOrderInventoryItem(id: 1,
                                                                 inventoryItemId: 1,
                                                                 unitPrice: 1,
                                                                 quantity: 1,
                                                                 totalPrice: 0,
                                                                 stocked: false);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid total price. Smaller or equal than zero.");
        }

    }
}
