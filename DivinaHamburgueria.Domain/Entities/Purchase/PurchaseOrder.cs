using DivinaHamburgueria.Domain.Validation;
using System;
using System.Collections.Generic;

namespace DivinaHamburgueria.Domain.Entities
{
    public class PurchaseOrder: Entity
    {

        public PurchaseOrder(PurchaseOrderState state, Decimal total, string? observation = null,
                             DateTime? creationDate = null, DateTime? quotationDate = null,
                             DateTime? issuedDate = null, DateTime? canceledDate = null,
                             DateTime? arrivedDate = null, DateTime? stockedDate = null,
                             DateTime? paymentDate = null)
        {
            //called by entity framework
            ValidateDomain(state, observation,
                           creationDate, quotationDate,
                           issuedDate, canceledDate,
                           arrivedDate, stockedDate,
                           paymentDate, total);
        }

        public PurchaseOrder(int id, PurchaseOrderState state, Decimal total, string? observation = null,
                             DateTime? creationDate = null, DateTime? quotationDate = null,
                             DateTime? issuedDate = null, DateTime? canceledDate = null,
                             DateTime? arrivedDate = null, DateTime? stockedDate = null,
                             DateTime? paymentDate = null)            
        {
            //called by mapper
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            ValidateDomain(state, observation,
                           creationDate, quotationDate,
                           issuedDate, canceledDate,
                           arrivedDate, stockedDate,
                           paymentDate, total);
        }

        private void ValidateDomain(PurchaseOrderState state, string? observation,
                                    DateTime? creationDate, DateTime? quotationDate,
                                    DateTime? issuedDate, DateTime? canceledDate,
                                    DateTime? arrivedDate, DateTime? stockedDate,
                                    DateTime? paymentDate, Decimal total)
        {
            DomainExceptionValidation.When(total <= 0, "Invalid total. Smaller or equal than zero.");
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

        public Decimal Total { get; private set; }

        public ICollection<PurchaseOrderInventoryItem>? PurchaseOrderInventoryItems { get; private set; }

    }
}
