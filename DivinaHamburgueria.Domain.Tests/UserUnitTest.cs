using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;
using static DivinaHamburgueria.Domain.Entities.User;

namespace DivinaHamburgueria.Domain.Tests
{
    public class UserUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateUser_WithValidParameters_ObjectValidState()
        {
            Action action = () => new User(id: 1,
                                           name: "João", 
                                           type: UserType.Cashier, 
                                           state: UserState.Active,
                                           email: "1@2com.br", 
                                           password: "12345678");
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateUser_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new User(id: -1,
                                           name: "João",
                                           type: UserType.Cashier,
                                           state: UserState.Active,
                                           email: "1@2com.br",
                                           password: "12345678");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreateUser_EmptyName_DomainExceptionInvalid()
        {
            Action action = () => new User(id: 1,
                                           name: "",
                                           type: UserType.Cashier,
                                           state: UserState.Active,
                                           email: "1@2com.br",
                                           password: "12345678");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreateUser_ShortName_DomainExceptionInvalid()
        {
            Action action = () => new User(id: 1,
                                           name: "Jo",
                                           type: UserType.Cashier,
                                           state: UserState.Active,
                                           email: "1@2com.br",
                                           password: "12345678");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact]
        public void CreateUser_TypeOutOfRange_DomainExceptionInvalid()
        {
            Action action = () => new User(id: 1,
                                           name: "João",
                                           type: (UserType) 4,
                                           state: UserState.Active,
                                           email: "1@2com.br",
                                           password: "12345678");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid type. Out of range 1 to 3.");
        }

        [Fact]
        public void CreateUser_StateOutOfRange_DomainExceptionInvalid()
        {
            Action action = () => new User(id: 1,
                                           name: "João",
                                           type: UserType.Cashier,
                                           state: (UserState) 2,
                                           email: "1@2com.br",
                                           password: "12345678");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid state. Out of range 0 to 1.");
        }

        [Fact]
        public void CreateUser_EmailWithOut_DomainExceptionInvalid()
        {
            Action action = () => new User(id: 1,
                                           name: "João",
                                           type: UserType.Cashier,
                                           state: UserState.Inactive,
                                           email: "1#2com.br",
                                           password: "12345678");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid email. Must have a @ character.");
        }

        [Fact]
        public void CreateUser_EmptyPassword_DomainExceptionInvalid()
        {
            Action action = () => new User(id: 1,
                                           name: "João",
                                           type: UserType.Cashier,
                                           state: UserState.Active,
                                           email: "1@2com.br",
                                           password: "");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid password. Password is required.");
        }

        [Fact]
        public void CreateUser_ShortPassword_DomainExceptionInvalid()
        {
            Action action = () => new User(id: 1,
                                           name: "João",
                                           type: UserType.Cashier,
                                           state: UserState.Active,
                                           email: "1@2com.br",
                                           password: "1234567");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid password, too short, minimum 8 characters.");
        }

    }
}
