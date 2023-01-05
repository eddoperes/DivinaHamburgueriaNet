using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests
{
    public class EatableUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateEatable_WithValidParameters_ObjectValidState()
        {
            Action action = () => new Eatable(id: 1, name: "Maionese");
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateEatable_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new Eatable(id: -1, name: "Maionese");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreateEatable_EmptyName_DomainExceptionInvalid()
        {
            Action action = () => new Eatable(id: 1, name: "");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreateEatable_ShortName_DomainExceptionInvalid()
        {
            Action action = () => new Eatable(id: 1, name: "Ma");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

    }
}
