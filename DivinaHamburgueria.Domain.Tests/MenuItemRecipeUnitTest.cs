using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests
{
    public class MenuItemRecipeUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateMenuItemRecipe_WithValidParameters_ObjectValidState()
        {
            Action action = () => new MenuItemRecipe(id: 1, 
                                                     name: "Big Divino", 
                                                     description: "Pão, hamburguer, alface, tomate, maionese", 
                                                     photo: "\\photos\\bigdivino.jpg");
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateMenuItemRecipe_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new MenuItemRecipe(id: -1,
                                                     name: "Big Divino",
                                                     description: "Pão, hamburguer, alface, tomate, maionese",
                                                     photo: "\\photos\\bigdivino.jpg");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreateMenuItemRecipe_EmptyName_DomainExceptionInvalid()
        {
            Action action = () => new MenuItemRecipe(id: 1,
                                                    name: "",
                                                    description: "Pão, hamburguer, alface, tomate, maionese",
                                                    photo: "\\photos\\bigdivino.jpg");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid name. Name must be informed.");
        }

        [Fact]
        public void CreateMenuItemRecipe_EmptyDescription_DomainExceptionInvalid()
        {
            Action action = () => new MenuItemRecipe(id: 1,
                                                    name: "Big Divino",
                                                    description: "",
                                                    photo: "\\photos\\bigdivino.jpg");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid description. Description must be informed.");
        }

        [Fact]
        public void CreateMenuItemRecipe_EmptyPhoto_DomainExceptionInvalid()
        {
            Action action = () => new MenuItemRecipe(id: 1,
                                                    name: "Big Divino",
                                                    description: "Pão, hamburguer, alface, tomate, maionese",
                                                    photo: "");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid photo. Photo must be informed.");
        }

    }
}
