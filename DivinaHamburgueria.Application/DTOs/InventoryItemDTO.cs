using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DivinaHamburgueria.Application.DTOs
{
    public class InventoryItemDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; } = String.Empty;

        [MaxLength(100)]
        [DisplayName("Brand")]
        public string? Brand { get; set; }

        [DisplayName("Content")]
        public int Content { get; set; }

        [DisplayName("UnityId")]
        public int UnityId { get; set; }

        [DisplayName("Type")]
        public int Type { get; set; }

    }
}
