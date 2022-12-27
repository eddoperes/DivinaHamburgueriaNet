using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;
using static DivinaHamburgueria.Domain.Entities.HallOrder;

namespace DivinaHamburgueria.Domain.Tests
{
    public class HallOrderUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void HallOrder_WithValidParameters_ObjectValidState()
        {
            Action action = () => new HallOrder(id: 1,
                                                userId: 1,
                                                customerId: 1,
                                                total: 1,
                                                state: HallOrderState.Issued);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void HallOrder_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new HallOrder(id: -1,
                                                userId: 1,
                                                customerId: 1,
                                                total: 1,
                                                state: HallOrderState.Issued);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void HallOrder_NegativeUserId_DomainExceptionInvalid()
        {
            Action action = () => new HallOrder(id: 1,
                                                userId: -1,
                                                customerId: 1,
                                                total: 1,
                                                state: HallOrderState.Issued);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid user id. Smaller or equal than zero.");
        }

        [Fact]
        public void HallOrder_NegativeCustomerId_DomainExceptionInvalid()
        {
            Action action = () => new HallOrder(id: 1,
                                                userId: 1,
                                                customerId: -1,
                                                total: 1,
                                                state: HallOrderState.Issued);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid customer id. Smaller or equal than zero.");
        }

        [Fact]
        public void HallOrder_ZeroTotal_DomainExceptionInvalid()
        {
            Action action = () => new HallOrder(id: 1,
                                                userId: 1,
                                                customerId: 1,
                                                total: 0,
                                                state: HallOrderState.Issued);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid total. Smaller or equal than zero.");
        }

        [Fact]
        public void HallOrder_StateOutOfRange_DomainExceptionInvalid()
        {
            Action action = () => new HallOrder(id: 1,
                                                userId: 1,
                                                customerId: 1,
                                                total: 1,
                                                state: 0);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid state. Out of range 1 to 3.");
        }

    }

}
