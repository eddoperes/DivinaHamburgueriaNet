using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DivinaHamburgueria.Application.DTOs
{
    public class MenuDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The description is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Description")]
        public string Description { get; set; } = string.Empty;

        [Range(0,1)]
        [DisplayName("State")]
        public int State { get; set; }

        [DisplayName("MenusMenuItems")]
        public ICollection<MenuMenuItemDTO>? MenuMenuItems { get; set;}

    }
}
