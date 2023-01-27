using System.ComponentModel;

namespace DivinaHamburgueria.Application.DTOs
{
    public class HallOrderPatchDTO
    {

        public int Id { get; set; }

        [DisplayName("State")]
        public int State { get; set; } = 1;

    }
}
