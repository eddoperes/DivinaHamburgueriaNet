using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests
{
    public class DeliveryOrderMenuItemUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void DeliveryOrderMenuItem_WithValidParameters_ObjectValidState()
        {
            Action action = () => new DeliveryOrderMenuItem(id: 1,
                                                            menuItemId: 1, 
                                                            price: 1);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void DeliveryOrderMenuItem_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new DeliveryOrderMenuItem(id: -1,
                                                            menuItemId: 1,
                                                            price: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void DeliveryOrderMenuItem_NegativeMenuItemId_DomainExceptionInvalid()
        {
            Action action = () => new DeliveryOrderMenuItem(id: 1,
                                                            menuItemId: -1,
                                                            price: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid menu item id. Smaller or equal than zero.");
        }

        [Fact]
        public void DeliveryOrderMenuItem_ZeroPrice_DomainExceptionInvalid()
        {
            Action action = () => new DeliveryOrderMenuItem(id: 1,
                                                            menuItemId: 1,
                                                            price: 0);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid price. Smaller or equal than zero.");
        }

    }
}
