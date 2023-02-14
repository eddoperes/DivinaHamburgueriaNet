using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Tests.Builders;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests.DomainTests
{
    public class DeliveryOrderMenuItemUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void DeliveryOrderMenuItem_WithValidParameters_ObjectValidState()
        {
            /*
            Action action = () => new DeliveryOrderMenuItem(id: 1,
                                                            menuItemId: 1,
                                                            price: 1);
            */

            Action action = () => DeliveryOrderMenuItemBuilder.New().Build();
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void DeliveryOrderMenuItem_NegativeId_DomainExceptionInvalid()
        {
            /*
            Action action = () => new DeliveryOrderMenuItem(id: -1,
                                                            menuItemId: 1,
                                                            price: 1);
            */

            Action action = () => DeliveryOrderMenuItemBuilder.New().ApplyId(-1).Build();
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void DeliveryOrderMenuItem_NegativeMenuItemId_DomainExceptionInvalid()
        {
            /*
            Action action = () => new DeliveryOrderMenuItem(id: 1,
                                                            menuItemId: -1,
                                                            price: 1);
            */
            Action action = () => DeliveryOrderMenuItemBuilder.New().ApplyMenuItemId(-1).Build();
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid menu item id. Smaller or equal than zero.");
        }

        [Fact]
        public void DeliveryOrderMenuItem_ZeroPrice_DomainExceptionInvalid()
        {
            /*
            Action action = () => new DeliveryOrderMenuItem(id: 1,
                                                            menuItemId: 1,
                                                            price: 0);
            */
            Action action = () => DeliveryOrderMenuItemBuilder.New().ApplyPrice(0).Build();
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid price. Smaller or equal than zero.");
        }

    }
}
