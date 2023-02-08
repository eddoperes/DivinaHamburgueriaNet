using System.Collections.Generic;
using System.ComponentModel;

namespace DivinaHamburgueria.Application.DTOs
{
    public class HallOrderDTO
    {

        public int Id { get; set; }

        public int UserId { get; set; }

        public string? Observation { get; set; }

        public int? CustomerId { get; set; }

        public decimal Total { get; set; }

        [DisplayName("State")]
        public int State { get; set; } = 1;

        public bool Supervised { get; set; }

        public ICollection<HallOrderMenuItemDTO>? HallOrderMenuItems { get; set; }

    }
}
