using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests.DomainTests
{
    public class UnityUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateUnity_WithValidParameters_ObjectValidState()
        {
            Action action = () => new Unity(id: 1, name: "Grama");
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateUnity_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new Unity(id: -1, name: "Grama");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreateUnity_EmptyName_DomainExceptionInvalid()
        {
            Action action = () => new Unity(id: 1, name: "");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreateUnity_ShortName_DomainExceptionInvalid()
        {
            Action action = () => new Unity(id: 1, name: "Gr");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

    }
}
