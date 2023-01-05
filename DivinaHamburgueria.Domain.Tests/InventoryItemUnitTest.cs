using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;
using static DivinaHamburgueria.Domain.Entities.InventoryItem;

namespace DivinaHamburgueria.Domain.Tests
{
    public class InventoryItemUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateInventoryItem_WithValidParameters_ObjectValidState()
        {
            Action action = () => new InventoryItem(id: 1,
                                                    brand: "", 
                                                    content: 300,
                                                    unityId: 1, 
                                                    type: InventoryItemType.Recipe, 
                                                    eatableId: 1);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateInventoryItem_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new InventoryItem(id: -1,
                                                    brand: "",
                                                    content: 300,
                                                    unityId: 1,
                                                    type: InventoryItemType.Recipe,
                                                    eatableId: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreateInventoryItem_ZeroContent_DomainExceptionInvalid()
        {
            Action action = () => new InventoryItem(id: 1,
                                                    brand: "",
                                                    content: 0,
                                                    unityId: 1,
                                                    type: InventoryItemType.Recipe,
                                                    eatableId: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid content. Smaller or equal than zero.");
        }


        [Fact]
        public void CreateInventoryItem_NegativeUnityId_DomainExceptionInvalid()
        {
            Action action = () => new InventoryItem(id: 1,
                                                    brand: "",
                                                    content: 300,
                                                    unityId: -1,
                                                    type: InventoryItemType.Recipe,
                                                    eatableId: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid unit id. Smaller or equal than zero.");
        }

        [Fact]
        public void CreateInventoryItem_TypeOutOfRange_DomainExceptionInvalid()
        {
            Action action = () => new InventoryItem(id: 1,
                                                    brand: "",
                                                    content: 300,
                                                    unityId: 1,
                                                    type: (InventoryItem.InventoryItemType) 3,
                                                    eatableId: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid type. Out of range 1 to 2.");
        }

        [Fact]
        public void CreateInventoryItem_NegativeEatableId_DomainExceptionInvalid()
        {
            Action action = () => new InventoryItem(id: 1,
                                                    brand: "",
                                                    content: 300,
                                                    unityId: 1,
                                                    type: InventoryItemType.Recipe,
                                                    eatableId: -1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid eatable id. Smaller than zero.");
        }

    }
}
