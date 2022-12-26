using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DivinaHamburgueria.Domain.Entities.MenuMenuItem;
using static DivinaHamburgueria.Domain.Entities.User;

namespace DivinaHamburgueria.Domain.Tests
{
    public class MenuMenuItemUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateMenuMenuItem_WithValidParameters_ObjectValidState()
        {
            Action action = () => new MenuMenuItem(id: 1, 
                                                   menuItemId: 1, 
                                                   price: 1, 
                                                   state: 0);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateMenuMenuItem_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new MenuMenuItem(id: -1,
                                                   menuItemId: 1,
                                                   price: 1,
                                                   state: 0);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreateMenuMenuItem_NegativeMenuItemId_DomainExceptionInvalid()
        {
            Action action = () => new MenuMenuItem(id: 1,
                                                   menuItemId: -1,
                                                   price: 1,
                                                   state: 0);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid menu item id. Smaller or equal than zero.");
        }

        [Fact]
        public void CreateMenuMenuItem_ZeroPrice_DomainExceptionInvalid()
        {
            Action action = () => new MenuMenuItem(id: 1,
                                                   menuItemId: 1,
                                                   price: 0,
                                                   state: 0);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid price. Smaller or equal than zero.");
        }

        [Fact]
        public void CreateMenuMenuItem_StateOutOfRange_DomainExceptionInvalid()
        {
            Action action = () => new MenuMenuItem(id: 1,
                                             menuItemId: 1,
                                             price: 1,
                                             state: (MenuMenuItem.MenuMenuItemState) 2);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid state. Out of range 0 to 1.");

        }

    }
}
