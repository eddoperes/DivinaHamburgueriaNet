using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests
{
    public class InventoryUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateInventory_WithValidParameters_ObjectValidState()
        {
            Action action = () => new Inventory(id: 1, 
                                                inventoryItemId: 1, 
                                                quantity: 1);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateInventory_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new Inventory(id: -1,
                                                inventoryItemId: 1,
                                                quantity: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreateInventory_NegativeEatableId_DomainExceptionInvalid()
        {
            Action action = () => new Inventory(id: 1,
                                                inventoryItemId: -1,
                                                quantity: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid inventory item id. Smaller or equal than zero.");
        }


    }
}
