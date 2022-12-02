using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DivinaHamburgueria.Application.DTOs
{
    public class PurchaseOrderPatchDTO
    {

        public int Id { get; set; }

        [DisplayName("State")]
        public int State { get; set; } = 1;

        [DisplayName("Payment")]
        public int Payment { get; set; } = 1;

    }
}
