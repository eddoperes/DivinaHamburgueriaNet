using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class HallOrder : Order
    {

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

    }
}
