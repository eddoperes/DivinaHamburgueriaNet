using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests.DomainTests
{
    public class ValidityAlarmTriggeredUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateValidityAlarmTriggered_WithValidParameters_ObjectValidState()
        {
            Action action = () => new ValidityAlarmTriggered(id: 1,
                                                             eatableId: 1,
                                                             validityInDays: 1,
                                                             possiblySpoiled: 2, 
                                                             unityId: 1,
                                                             updated: DateTime.Now);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateValidityAlarmTriggered_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new ValidityAlarmTriggered(id: -1,
                                                             eatableId: 1,
                                                             validityInDays: 1,
                                                             possiblySpoiled: 2,
                                                             unityId: 1,
                                                             updated: DateTime.Now);
            action.Should().Throw<Domain.Validation
                            .DomainExceptionValidation>()
                            .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreateValidityAlarmTriggered_NegativeEatableId_DomainExceptionInvalid()
        {
            Action action = () => new ValidityAlarmTriggered(id: 1,
                                                             eatableId: -1,
                                                             validityInDays: 1,
                                                             possiblySpoiled: 2,
                                                             unityId: 1,
                                                             updated: DateTime.Now);
            action.Should().Throw<Domain.Validation
                            .DomainExceptionValidation>()
                            .WithMessage("Invalid eatable id. Smaller or equal than zero.");
        }

        [Fact]
        public void CreateValidityAlarmTriggered_ValidityInDaysZero_DomainExceptionInvalid()
        {
            Action action = () => new ValidityAlarmTriggered(id: 1,
                                                             eatableId: 1,
                                                             validityInDays: 0,
                                                             possiblySpoiled: 2,
                                                             unityId: 1,
                                                             updated: DateTime.Now);
            action.Should().Throw<Domain.Validation
                            .DomainExceptionValidation>()
                            .WithMessage("Invalid validity in days. Smaller or equal than zero.");
        }

        [Fact]
        public void CreateValidityAlarmTriggered_VerifiedInDaysNotBiggerValidityInDays_DomainExceptionInvalid()
        {
            Action action = () => new ValidityAlarmTriggered(id: 1,
                                                             eatableId: 1,
                                                             validityInDays: 1,
                                                             possiblySpoiled: 0,
                                                             unityId: 1,
                                                             updated: DateTime.Now);
            action.Should().Throw<Domain.Validation
                            .DomainExceptionValidation>()
                            .WithMessage("Invalid possibly spoiled. Smaller or equal than zero.");
        }

    }
}
