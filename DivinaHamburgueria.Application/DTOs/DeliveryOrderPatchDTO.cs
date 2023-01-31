using System.ComponentModel;

namespace DivinaHamburgueria.Application.DTOs
{
    public class DeliveryOrderPatchDTO
    {

        public int Id { get; set; }

        [DisplayName("State")]
        public int State { get; set; } = 1;

        [DisplayName("Payment")]
        public int Payment { get; set; } = 1;

    }
}
