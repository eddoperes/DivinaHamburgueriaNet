using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;
using static DivinaHamburgueria.Domain.Entities.DeliveryOrder;

namespace DivinaHamburgueria.Domain.Tests
{
    public class DeliveryOrderUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void DeliveryOrder_WithValidParameters_ObjectValidState()
        {
            Action action = () => new DeliveryOrder(id: 1,
                                                    userId: 1,
                                                    customerId: 1,
                                                    total: 1,
                                                    state: DeliveryOrderState.Issued,
                                                    payment: DeliveryOrderPayment.Opened);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void DeliveryOrder_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new DeliveryOrder(id: -1,
                                                    userId: 1,
                                                    customerId: 1,
                                                    total: 1,
                                                    state: DeliveryOrderState.Issued,
                                                    payment: DeliveryOrderPayment.Opened);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void DeliveryOrder_NegativeUserId_DomainExceptionInvalid()
        {
            Action action = () => new DeliveryOrder(id: 1,
                                                    userId: -1,
                                                    customerId: 1,
                                                    total: 1,
                                                    state: DeliveryOrderState.Issued,
                                                    payment: DeliveryOrderPayment.Opened);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid user id. Smaller or equal than zero.");
        }

        [Fact]
        public void DeliveryOrder_NegativeCustomerId_DomainExceptionInvalid()
        {
            Action action = () => new DeliveryOrder(id: 1,
                                                    userId: 1,
                                                    customerId: -1,
                                                    total: 1,
                                                    state: DeliveryOrderState.Issued,
                                                    payment: DeliveryOrderPayment.Opened);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid customer id. Smaller or equal than zero.");
        }

        [Fact]
        public void DeliveryOrder_ZeroTotal_DomainExceptionInvalid()
        {
            Action action = () => new DeliveryOrder(id: 1,
                                                    userId: 1,
                                                    customerId: 1,
                                                    total: 0,
                                                    state: DeliveryOrderState.Issued,
                                                    payment: DeliveryOrderPayment.Opened);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid total. Smaller or equal than zero.");
        }

        [Fact]
        public void DeliveryOrder_StateOutOfRange_DomainExceptionInvalid()
        {
            Action action = () => new DeliveryOrder(id: 1,
                                                    userId: 1,
                                                    customerId: 1,
                                                    total: 1,
                                                    state: 0,
                                                    payment: DeliveryOrderPayment.Opened);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid state. Out of range 1 to 4.");
        }

        [Fact]
        public void DeliveryOrder_PaymentOutOfRange_DomainExceptionInvalid()
        {
            Action action = () => new DeliveryOrder(id: 1,
                                                    userId: 1,
                                                    customerId: 1,
                                                    total: 1,
                                                    state: DeliveryOrderState.Issued,
                                                    payment: 0);
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid payment. Out of range 1 to 2.");
        }


    }
}
