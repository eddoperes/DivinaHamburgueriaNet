using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests
{
    public class ProviderUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateProvider_WithValidParameters_ObjectValidState()
        {
            Action action = () => new Provider(id: 1, name: "Assai", cnpj: "00000000000272");
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }


        [Fact]
        public void CreateProvider_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new Provider(id: -1, name: "Assai", cnpj: "00000000000272");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreateProvider_InvalidCNPJ_DomainExceptionInvalid()
        {
            Action action = () => new Provider(id: 1, name: "Assai", cnpj: "00000000000999");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid CNPJ.");
        }

        [Fact]
        public void CreateProvider_EmptyName_DomainExceptionInvalid()
        {
            Action action = () => new Provider(id: 1, name: "", cnpj: "00000000000272");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreateProvider_ShortName_DomainExceptionInvalid()
        {
            Action action = () => new Provider(id: 1, name: "As", cnpj: "00000000000272");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid name, too short, minimum 3 characters.");
        }


    }
}