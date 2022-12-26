using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class DeliveryOrder: Order
    {

        public enum DeliveryOrderState
        {
            Issued = 1,
            Canceled = 2,
            Packaged = 3,
            Delivered = 4
        }

        public enum DeliveryOrderPaymentState
        {
            Opened = 1,
            Paid = 2
        }

        public DeliveryOrderState State = DeliveryOrderState.Issued;

        public DateTime? IssuedDate { get; private set; }

        public DateTime? CanceledDate { get; private set; }

        public DateTime? PackagedDate { get; private set; }

        public DateTime? DeliveredDate { get; private set; }

        public DeliveryOrderPaymentState Payment { get; private set; } = DeliveryOrderPaymentState.Opened;

        public DateTime? PaymentDate { get; private set; }

        public ICollection<DeliveryOrderMenuItem>? DeliveryOrderMenuItems { get; private set; }

    }
}
