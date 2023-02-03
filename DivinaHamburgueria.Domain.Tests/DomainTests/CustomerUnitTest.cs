using DivinaHamburgueria.Domain;
using DivinaHamburgueria.Domain.Tests.Builders;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests.DomainTests
{
    public class CustomerUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateCustomer_WithValidParameters_ObjectValidState()
        {
            //Action action = () => new Customer(id: 1, name: "João", cpf: "11111111111");

            Action action = () => CustomerBuilder.New().Build();
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCustomer_NegativeId_DomainExceptionInvalid()
        {
            //Action action = () => new Customer(id: -1, name: "João", cpf: "11111111111");

            Action action = () => CustomerBuilder.New().ApplyId(-1).Build();
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreateCustomer_InvalidCPF_DomainExceptionInvalid()
        {
            //Action action = () => new Customer(id: 1, name: "João", cpf: "11111111999");

            Action action = () => CustomerBuilder.New().ApplyCPF("11111111999").Build();
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid CPF.");
        }

        [Fact]
        public void CreateCustomer_EmptyName_DomainExceptionInvalid()
        {
            //Action action = () => new Customer(id: 1, name: "", cpf: "11111111111");

            Action action = () => CustomerBuilder.New().ApplyName("").Build();
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreateCustomer_ShortName_DomainExceptionInvalid()
        {
            // Action action = () => new Customer(id: 1, name: "Jo", cpf: "11111111111");

            Action action = () => CustomerBuilder.New().ApplyName("Jo").Build();
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

    }
}
