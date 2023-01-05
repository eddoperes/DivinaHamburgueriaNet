using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests
{
    public class MenuItemResaleUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateMenuItemRecipe_WithValidParameters_ObjectValidState()
        {
            Action action = () => new MenuItemResale(id: 1,
                                                     name: "Coca-cola",
                                                     description: "Refrigerante de cola",
                                                     photo: "\\photos\\coca-cola.jpg",
                                                     inventoryItemId: 1);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateMenuItemRecipe_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new MenuItemResale(id: -1,
                                                     name: "Coca-cola",
                                                     description: "Refrigerante de cola",
                                                     photo: "\\photos\\coca-cola.jpg",
                                                     inventoryItemId: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreateMenuItemRecipe_EmptyName_DomainExceptionInvalid()
        {
            Action action = () => new MenuItemResale(id: 1,
                                                    name: "",
                                                    description: "Refrigerante de cola",
                                                    photo: "\\photos\\coca-cola.jpg",
                                                    inventoryItemId: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid name. Name must be informed.");
        }

        [Fact]
        public void CreateMenuItemRecipe_EmptyDescription_DomainExceptionInvalid()
        {
            Action action = () => new MenuItemResale(id: 1,
                                                    name: "Coca-cola",
                                                    description: "",
                                                    photo: "\\photos\\coca-cola.jpg",
                                                    inventoryItemId: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid description. Description must be informed.");
        }

        [Fact]
        public void CreateMenuItemRecipe_EmptyPhoto_DomainExceptionInvalid()
        {
            Action action = () => new MenuItemResale(id: 1,
                                                    name: "Coca-cola",
                                                    description: "Refrigerante de cola",
                                                    photo: "",
                                                    inventoryItemId: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid photo. Photo must be informed.");
        }

        [Fact]
        public void CreateMenuItemRecipe_NegativeInventoryItemId_DomainExceptionInvalid()
        {
            Action action = () => new MenuItemResale(id: 1,
                                        name: "Coca-cola",
                                        description: "Refrigerante de cola",
                                        photo: "\\photos\\coca-cola.jpg",
                                        inventoryItemId: -1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid inventory item id. Smaller or equal than zero.");
        }

    }
}
