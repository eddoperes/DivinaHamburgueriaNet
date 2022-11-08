using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static DivinaHamburgueria.Domain.Entities.PurchaseOrder;

namespace DivinaHamburgueria.Application.DTOs
{
    public class PurchaseOrderDTO
    {

        public int Id { get; set; }

        [DisplayName("ProviderId")]
        public int ProviderId { get; set; }

        //public Provider? Provider { get; set; }

        [DisplayName("State")]
        public int State { get; set; }

        [DisplayName("Observation")]
        public string Observation { get; set; } = string.Empty;

        [DisplayName("Payment")]
        public int Payment { get; set; }

        [DisplayName("Total")]
        public Decimal Total { get; set; }

        [DisplayName("PurchaseOrderInventoryItems")]
        public ICollection<PurchaseOrderInventoryItemDTO>? PurchaseOrderInventoryItems { get; set; }



    }
}
