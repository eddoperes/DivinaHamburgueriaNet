using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DivinaHamburgueria.Application.DTOs
{
    public class PurchaseOrderDTO
    {

        public int Id { get; set; }

        [DisplayName("ProviderId")]
        public int ProviderId { get; set; }

        [DisplayName("State")]
        public int State { get; set; } = 1;

        [DisplayName("Observation")]
        public string Observation { get; set; } = string.Empty;

        [DisplayName("Payment")]
        public int Payment { get; set; } = 1;

        [DisplayName("Total")]
        public Decimal Total { get; set; }

        [DisplayName("PurchaseOrderInventoryItems")]
        public ICollection<PurchaseOrderInventoryItemDTO>? PurchaseOrderInventoryItems { get; set; }



    }
}
