using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests.DomainTests
{
    public class QuantityAlarmTriggeredUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateQuantityAlarmTriggered_WithValidParameters_ObjectValidState()
        {
            Action action = () => new QuantityAlarmTriggered(id: 1,
                                                             eatableId: 1,
                                                             minimumQuantity: 3,
                                                             verifiedQuantity: 2,
                                                             unityId: 1,
                                                             updated: DateTime.Now);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateQuantityAlarmTriggered_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new QuantityAlarmTriggered(id: -1,
                                                             eatableId: 1,
                                                             minimumQuantity: 1,
                                                             verifiedQuantity: 2,
                                                             unityId: 1,
                                                             updated: DateTime.Now);
            action.Should().Throw<Domain.Validation
                            .DomainExceptionValidation>()
                            .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreateQuantityAlarmTriggered_NegativeEatableId_DomainExceptionInvalid()
        {
            Action action = () => new QuantityAlarmTriggered(id: 1,
                                                             eatableId: -1,
                                                             minimumQuantity: 1,
                                                             verifiedQuantity: 2,
                                                             unityId: 1,
                                                             updated: DateTime.Now);
            action.Should().Throw<Domain.Validation
                            .DomainExceptionValidation>()
                            .WithMessage("Invalid eatable id. Smaller or equal than zero.");
        }

        [Fact]
        public void CreateQuantityAlarmTriggered_MinimumQuantityZero_DomainExceptionInvalid()
        {
            Action action = () => new QuantityAlarmTriggered(id: 1,
                                                             eatableId: 1,
                                                             minimumQuantity: 0,
                                                             verifiedQuantity: 2,
                                                             unityId: 1,
                                                             updated: DateTime.Now);
            action.Should().Throw<Domain.Validation
                            .DomainExceptionValidation>()
                            .WithMessage("Invalid minimum quantity. Smaller or equal than zero.");
        }

        [Fact]
        public void CreateQuantityAlarmTriggered_VerifiedQuantityNotBiggerMinimumQuantity_DomainExceptionInvalid()
        {
            Action action = () => new QuantityAlarmTriggered(id: 1,
                                                             eatableId: 1,
                                                             minimumQuantity: 3,
                                                             verifiedQuantity: 4,
                                                             unityId: 1,
                                                             updated: DateTime.Now);
            action.Should().Throw<Domain.Validation
                            .DomainExceptionValidation>()
                            .WithMessage("Invalid verified quantity. Bigger than minimum quantity.");
        }

        [Fact]
        public void CreateQuantityAlarmTriggered_NegativeUnityId_DomainExceptionInvalid()
        {
            Action action = () => new QuantityAlarmTriggered(id: 1,
                                                             eatableId: 1,
                                                             minimumQuantity: 3,
                                                             verifiedQuantity: 2,
                                                             unityId: -1,
                                                             updated: DateTime.Now);
            action.Should().Throw<Domain.Validation
                            .DomainExceptionValidation>()
                            .WithMessage("Invalid unity id. Smaller or equal than zero.");
        }

    }
}
