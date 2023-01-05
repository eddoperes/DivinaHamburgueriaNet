using DivinaHamburgueria.Domain.Entities;
using FluentAssertions;

namespace DivinaHamburgueria.Domain.Tests
{
    public class PurchaseOrderUnitTest
    {

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreatePurchaseOrder_WithValidParameters_ObjectValidState()
        {
            Action action = () => new PurchaseOrder(id: 1,
                                                    providerId: 1,
                                                    state: PurchaseOrder.PurchaseOrderState.Quotation,
                                                    payment: PurchaseOrder.PurchaseOrderPayment.Opened,
                                                    total: 1,
                                                    observation: "Comentário");
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreatePurchaseOrder_NegativeId_DomainExceptionInvalid()
        {
            Action action = () => new PurchaseOrder(id: -1,
                                                    providerId: 1,
                                                    state: PurchaseOrder.PurchaseOrderState.Quotation,
                                                    payment: PurchaseOrder.PurchaseOrderPayment.Opened,
                                                    total: 1,
                                                    observation: "Comentário");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid id. Smaller than zero.");
        }

        [Fact]
        public void CreatePurchaseOrder_NegativeProviderId_DomainExceptionInvalid()
        {
            Action action = () => new PurchaseOrder(id: 1,
                                                    providerId: -1,
                                                    state: PurchaseOrder.PurchaseOrderState.Quotation,
                                                    payment: PurchaseOrder.PurchaseOrderPayment.Opened,
                                                    total: 1,
                                                    observation: "Comentário");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid provider id. Smaller or equal than zero.");
        }

        [Fact]
        public void CreatePurchaseOrder_StateOutOfRange_DomainExceptionInvalid()
        {
            Action action = () => new PurchaseOrder(id: 1,
                                                    providerId: 1,
                                                    state: 0,
                                                    payment: PurchaseOrder.PurchaseOrderPayment.Opened,
                                                    total: 1,
                                                    observation: "Comentário");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid state. Out of range 1 to 5.");
        }

        [Fact]
        public void CreatePurchaseOrder_PaymentOutOfRange_DomainExceptionInvalid()
        {
            Action action = () => new PurchaseOrder(id: 1,
                                                    providerId: 1,
                                                    state: PurchaseOrder.PurchaseOrderState.Quotation,
                                                    payment: 0,
                                                    total: 1,
                                                    observation: "Comentário");
            action.Should().Throw<Domain.Validation
                                        .DomainExceptionValidation>()
                                        .WithMessage("Invalid payment. Out of range 1 to 2.");
        }

    }
}
