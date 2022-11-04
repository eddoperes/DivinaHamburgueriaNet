using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class PurchaseOrder: Entity
    {

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

        public Provider? Provider { get; private set; }

        public PurchaseOrderState State { get; private set; } = PurchaseOrderState.Quotation;

        public string Observation { get; private set; } = string.Empty;

        public DateTime CreationDate { get; private set; }

        public DateTime QuotationDate { get; private set; }

        public DateTime IssuedDate { get; private set; }

        public DateTime CanceledDate { get; private set; }

        public DateTime ArrivedDate { get; private set; }

        public DateTime StockedDate { get; private set; }

        public PurchaseOrderPayment Payment { get; private set; } = PurchaseOrderPayment.Opened;

        public DateTime PaymentDate { get; private set; }

        public Decimal Total { get; private set; }

        public ICollection<PurchaseOrderInventoryItem>? PurchaseOrderInventoryItems { get; private set; }

    }
}
