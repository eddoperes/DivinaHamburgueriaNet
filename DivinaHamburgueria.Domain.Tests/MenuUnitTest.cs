using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests
{
    public class MenuUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateMenu_WithValidParameters_ObjectValidState()
        {
            Action action = () => new Menu(id: 1,
                                           name: "Segunda a sexta",
                                           description: "Cardápio para os dias úteis",
                                           state: Menu.MenuState.Active);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateMenu_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new Menu(id: -1,
                                           name: "Segunda a sexta",
                                           description: "Cardápio para os dias úteis",
                                           state: Menu.MenuState.Active);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreateMenu_EmptyName_DomainExceptionInvalid()
        {
            Action action = () => new Menu(id: 1,
                                           name: "",
                                           description: "Cardápio para os dias úteis",
                                           state: Menu.MenuState.Active);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid name. Name must be informed.");
        }

        [Fact]
        public void CreateMenu_EmptyDescription_DomainExceptionInvalid()
        {
            Action action = () => new Menu(id: 1,
                                           name: "Segunda a sexta",
                                           description: "",
                                           state: Menu.MenuState.Active);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid description. Description must be informed.");
        }

        [Fact]
        public void CreateMenu_StateOutOfRange_DomainExceptionInvalid()
        {
            Action action = () => new Menu(id: 1,
                                           name: "Segunda a sexta",
                                           description: "Cardápio para os dias úteis",
                                           state: (Menu.MenuState) 2);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid state. Out of range 0 to 1.");
        }


    }
}
