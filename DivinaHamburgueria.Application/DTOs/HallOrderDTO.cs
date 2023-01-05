using System.Collections.Generic;
using System.ComponentModel;

namespace DivinaHamburgueria.Application.DTOs
{
    public class HallOrderDTO
    {

        public int Id { get; set; }

        public int UserId { get; private set; }

        public string? Observation { get; private set; }

        public int CustomerId { get; private set; }

        public decimal Total { get; private set; }

        [DisplayName("State")]
        public int State { get; set; } = 1;

        public ICollection<HallOrderMenuItemDTO>? HallOrderMenuItems { get; set; }

    }
}
