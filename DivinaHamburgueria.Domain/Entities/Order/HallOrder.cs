using DivinaHamburgueria.Domain.Validation;
using System;
using System.Collections.Generic;

namespace DivinaHamburgueria.Domain.Entities
{
    public class HallOrder : Order
    {

        public HallOrder(int userId, decimal total,
                         HallOrderState state,
                         int? customerId = null,
                         DateTime? issuedDate = null, DateTime? canceledDate = null,
                         DateTime? servedDate = null,
                         string? observation = null, DateTime? creationDate = null) : base(userId, total, customerId,
                                                                                           observation, creationDate)
        {
            //called by entity framework   
            ValidateDomain(state,
                           issuedDate, canceledDate,
                           servedDate);
        }

        public HallOrder(int id, int userId, decimal total,
                             HallOrderState state,
                             int? customerId = null,
                             DateTime? issuedDate = null, DateTime? canceledDate = null,
                             DateTime? servedDate = null,
                             string? observation = null, DateTime? creationDate = null) : base(id, userId, total, customerId,
                                                                                               observation, creationDate)
        {
            //called by mapper
            ValidateDomain(state,
                           issuedDate, canceledDate,
                           servedDate);
        }

        private void ValidateDomain(HallOrderState state,
                                    DateTime? issuedDate = null, DateTime? canceledDate = null,
                                    DateTime? servedDate = null)
        {
            DomainExceptionValidation.When(state < HallOrderState.Issued || state > HallOrderState.Served, "Invalid state. Out of range 1 to 3.");            
            this.State = state;
            this.IssuedDate = issuedDate;
            this.CanceledDate = canceledDate;
            this.ServedDate = servedDate;
        }

        public enum HallOrderState
        {
            Issued = 1,
            Canceled = 2,
            Served = 3
        }

        public HallOrderState State { get; private set; } = HallOrderState.Issued;

        public DateTime? IssuedDate { get; private set; }

        public DateTime? CanceledDate { get; private set; }

        public DateTime? ServedDate { get; private set; }

        public ICollection<HallOrderMenuItem>? HallOrderMenuItems { get; private set; }

        public void RegisterState(HallOrderState state)
        {
            this.State = state;
            if (state == HallOrderState.Issued)
            {
                this.CreationDate = DateTime.Now;
                this.IssuedDate = DateTime.Now;
            }
            else if (state == HallOrderState.Canceled)
                this.CanceledDate = DateTime.Now;
            else if (state == HallOrderState.Served )
                this.ServedDate = DateTime.Now;
        }

    }
}
