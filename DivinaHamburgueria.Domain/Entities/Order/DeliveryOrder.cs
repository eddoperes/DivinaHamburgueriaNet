using DivinaHamburgueria.Domain.Validation;
using System;
using System.Collections.Generic;

namespace DivinaHamburgueria.Domain.Entities
{
    public class DeliveryOrder: Order
    {
        public DeliveryOrder(int userId, decimal total,
                             DeliveryOrderState state, DeliveryOrderPayment payment,
                             bool supervised, int? customerId = null,
                             DateTime? issuedDate = null, DateTime? canceledDate = null,
                             DateTime? packagedDate = null, DateTime? deliveredDate = null, DateTime? paymentDate = null,
                             string? observation = null, DateTime? creationDate = null) : base(userId, total, customerId,
                                                                                                       observation, creationDate)
        {
            //called by entity framework   
            ValidateDomain(state, payment, supervised,
                           issuedDate, canceledDate,
                           packagedDate, deliveredDate, paymentDate);
        }

        public DeliveryOrder(int id, int userId, decimal total,
                             DeliveryOrderState state, DeliveryOrderPayment payment,
                             bool supervised, int? customerId = null,
                             DateTime? issuedDate = null, DateTime? canceledDate = null,
                             DateTime? packagedDate = null, DateTime? deliveredDate = null, DateTime? paymentDate = null,
                             string? observation = null, DateTime? creationDate = null) : base(id, userId, total, customerId,
                                                                                                       observation, creationDate)
        {
            //called by mapper
            ValidateDomain(state, payment, supervised,
                           issuedDate, canceledDate,
                           packagedDate, deliveredDate, paymentDate);
        }

        private void ValidateDomain(DeliveryOrderState state, DeliveryOrderPayment payment,
                                    bool supervised,
                                    DateTime? issuedDate = null, DateTime? canceledDate = null,
                                    DateTime? packagedDate = null, DateTime? deliveredDate = null, DateTime? paymentDate = null)
        {
            DomainExceptionValidation.When(state < DeliveryOrderState.Issued || state > DeliveryOrderState.Delivered, "Invalid state. Out of range 1 to 4.");
            DomainExceptionValidation.When(payment < DeliveryOrderPayment.Opened || payment > DeliveryOrderPayment.Paid, "Invalid payment. Out of range 1 to 2.");
            this.State = state;
            this.Payment = payment;
            this.IssuedDate = issuedDate;
            this.CanceledDate = canceledDate;
            this.PackagedDate = packagedDate;
            this.DeliveredDate = deliveredDate;
            this.PackagedDate = paymentDate;
            this.Supervised = supervised;
        }

        public enum DeliveryOrderState
        {
            Issued = 1,
            Canceled = 2,
            Packaged = 3,
            Delivered = 4
        }

        public enum DeliveryOrderPayment
        {
            Opened = 1,
            Paid = 2
        }

        public DeliveryOrderState State { get; private set; } = DeliveryOrderState.Issued;

        public DateTime? IssuedDate { get; private set; }

        public DateTime? CanceledDate { get; private set; }

        public DateTime? PackagedDate { get; private set; }

        public DateTime? DeliveredDate { get; private set; }

        public DeliveryOrderPayment Payment { get; private set; } = DeliveryOrderPayment.Opened;

        public DateTime? PaymentDate { get; private set; }

        public bool Supervised { get; private set; }

        public ICollection<DeliveryOrderMenuItem>? DeliveryOrderMenuItems { get; private set; }

        public void RegisterState(DeliveryOrderState state)
        {
            this.State = state;
            if (state == DeliveryOrderState.Issued)
            {
                this.CreationDate = DateTime.Now;
                this.IssuedDate = DateTime.Now;
            }
            else if (state == DeliveryOrderState.Canceled)
                this.CanceledDate = DateTime.Now;
            else if (state == DeliveryOrderState.Packaged)
                this.PackagedDate = DateTime.Now;
            else if (state == DeliveryOrderState.Delivered)            
                this.DeliveredDate = DateTime.Now;                            
        }

        public void RegisterPayment(DeliveryOrderPayment payment)
        {
            this.Payment = payment;
            if (payment == DeliveryOrderPayment.Paid)
                this.PaymentDate = DateTime.Now;
        }

        public void NotifySupervised()
        {
            this.Supervised = true;
        }


    }
}
