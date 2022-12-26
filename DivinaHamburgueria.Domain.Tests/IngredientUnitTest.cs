using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests
{
    public class IngredientUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateIngredient_WithValidParameters_ObjectValidState()
        {
            Action action = () => new Ingredient(id: 1, eatableId: 1, quantity: 1, unityId: 1);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateIngredient_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new Ingredient(id: -1, eatableId: 1, quantity: 1, unityId: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreateIngredient_NegativeEatableId_DomainExceptionInvalid()
        {
            Action action = () => new Ingredient(id: 1, eatableId: -1, quantity: 1, unityId: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid eatable id. Smaller or equal than zero.");
        }

        [Fact]
        public void CreateIngredient_ZeroQuantity_DomainExceptionInvalid()
        {
            Action action = () => new Ingredient(id: 1, eatableId: 1, quantity: 0, unityId: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid quantity. Smaller or equal than zero.");
        }

        [Fact]
        public void CreateIngredient_NegativeUnitId_DomainExceptionInvalid()
        {
            Action action = () => new Ingredient(id: 1, eatableId: 1, quantity: 1, unityId: -1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid unit id. Smaller or equal than zero.");
        }


    }
}
