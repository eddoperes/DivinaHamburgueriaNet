using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Tests
{
    public class HallOrderMenuItemUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void HallOrderMenuItem_WithValidParameters_ObjectValidState()
        {
            Action action = () => new HallOrderMenuItem(id: 1,
                                                        menuItemId: 1,
                                                        price: 1);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void HallOrderMenuItem_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new HallOrderMenuItem(id: -1,
                                                        menuItemId: 1,
                                                        price: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void HallOrderMenuItem_NegativeMenuItemId_DomainExceptionInvalid()
        {
            Action action = () => new HallOrderMenuItem(id: 1,
                                                        menuItemId: -1,
                                                        price: 1);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid menu item id. Smaller or equal than zero.");
        }

        [Fact]
        public void HallOrderMenuItem_ZeroPrice_DomainExceptionInvalid()
        {
            Action action = () => new HallOrderMenuItem(id: 1,
                                                        menuItemId: 1,
                                                        price: 0);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid price. Smaller or equal than zero.");
        }

    }
}
