using DivinaHamburgueria.Domain.Validation;
using System;
using System.Collections.Generic;

namespace DivinaHamburgueria.Domain.Entities
{
    public class PurchaseOrder: Entity
    {

        public PurchaseOrder(int providerId, PurchaseOrderState state, PurchaseOrderPayment payment, decimal total, string? observation = null,
                             DateTime? creationDate = null, DateTime? quotationDate = null,
                             DateTime? issuedDate = null, DateTime? canceledDate = null,
                             DateTime? arrivedDate = null, DateTime? stockedDate = null,
                             DateTime? paymentDate = null)
        {
            //called by entity framework
            ValidateDomain(providerId, state, payment, total, observation,
                           creationDate, quotationDate,
                           issuedDate, canceledDate,
                           arrivedDate, stockedDate,
                           paymentDate);
        }

        public PurchaseOrder(int id, int providerId, PurchaseOrderState state, PurchaseOrderPayment payment, decimal total, string? observation = null,
                             DateTime? creationDate = null, DateTime? quotationDate = null,
                             DateTime? issuedDate = null, DateTime? canceledDate = null,
                             DateTime? arrivedDate = null, DateTime? stockedDate = null,
                             DateTime? paymentDate = null)            
        {
            //called by mapper
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            ValidateDomain(providerId, state, payment, total, observation,
                           creationDate, quotationDate,
                           issuedDate, canceledDate,
                           arrivedDate, stockedDate,
                           paymentDate);
        }

        private void ValidateDomain(int providerId, PurchaseOrderState state, PurchaseOrderPayment payment, decimal total, string? observation,
                                    DateTime? creationDate, DateTime? quotationDate,
                                    DateTime? issuedDate, DateTime? canceledDate,
                                    DateTime? arrivedDate, DateTime? stockedDate,
                                    DateTime? paymentDate)
        {
            DomainExceptionValidation.When(providerId <= 0, "Invalid provider id. Smaller or equal than zero.");
            DomainExceptionValidation.When(total <= 0, "Invalid total. Smaller or equal than zero.");
            DomainExceptionValidation.When(state < PurchaseOrderState.Quotation || state > PurchaseOrderState.Stocked, "Invalid state. Out of range 1 to 5.");
            DomainExceptionValidation.When(payment < PurchaseOrderPayment.Opened || payment > PurchaseOrderPayment.Paid, "Invalid payment. Out of range 1 to 2.");
            this.ProviderId = providerId;
            this.State = state;
            this.Observation = observation;
            this.CreationDate = creationDate;
            this.QuotationDate = quotationDate;
            this.IssuedDate = issuedDate;
            this.CanceledDate = canceledDate;
            this.ArrivedDate = arrivedDate;
            this.StockedDate = stockedDate;
            this.PaymentDate = paymentDate;
            this.Total = total;
        }

        public enum PurchaseOrderState
        {
            Quotation = 1,
            Issued = 2,
            Canceled = 3,
            Arrived = 4,
            Stocked = 5
        }

        public enum PurchaseOrderPayment
        {
            Opened = 1,
            Paid = 2
        }

        public int ProviderId { get; private set; }

        public Provider? Provider { get; private set; }

        public PurchaseOrderState State { get; private set; } = PurchaseOrderState.Quotation;

        public string? Observation { get; private set; }

        public DateTime? CreationDate { get; private set; }

        public DateTime? QuotationDate { get; private set; }

        public DateTime? IssuedDate { get; private set; }

        public DateTime? CanceledDate { get; private set; }

        public DateTime? ArrivedDate { get; private set; }

        public DateTime? StockedDate { get; private set; }

        public PurchaseOrderPayment Payment { get; private set; } = PurchaseOrderPayment.Opened;

        public DateTime? PaymentDate { get; private set; }

        public decimal Total { get; private set; }

        public ICollection<PurchaseOrderInventoryItem>? PurchaseOrderInventoryItems { get; private set; }


        public void RegisterState(PurchaseOrderState state)
        {
            this.State = state;
            if (state == PurchaseOrderState.Quotation)
            {
                this.CreationDate = DateTime.Now;
                this.QuotationDate = DateTime.Now;
            }
            else if (state == PurchaseOrderState.Issued)
                this.IssuedDate = DateTime.Now;
            else if (state == PurchaseOrderState.Canceled)
                this.CanceledDate = DateTime.Now;
            else if (state == PurchaseOrderState.Arrived)
                this.ArrivedDate = DateTime.Now;
            else if (state == PurchaseOrderState.Stocked)
                this.StockedDate = DateTime.Now;
        }

        public void RegisterPayment(PurchaseOrderPayment payment)
        {
            this.Payment = payment;
            if (payment == PurchaseOrderPayment.Paid)
                this.PaymentDate = DateTime.Now;
        }

    }
}
